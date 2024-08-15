using JT808.Protocol.Exceptions;
using JT808.Protocol.Extensions;
using JT808.Protocol.Formatters;
using JT808.Protocol.Interfaces;
using JT808.Protocol.MessagePack;
using JT808.Protocol.Metadata;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Buffers.Binary;

namespace JT808.Protocol.MessageBody
{
    /// <summary>
    /// CAN 总线数据上传
    /// 0x0705
    /// </summary>
    public class JT808_0x0705 : JT808Bodies, IJT808MessagePackFormatter<JT808_0x0705>, IJT808Analyze, IJT808_2019_Version
    {
        /// <summary>
        /// 0x0705
        /// </summary>
        public override ushort MsgId { get; } = 0x0705;
        /// <summary>
        /// CAN总线数据上传
        /// </summary>
        public override string Description => "CAN总线数据上传";
        /// <summary>
        /// 数据项个数
        /// 包含的 CAN 总线数据项个数，>0
        /// </summary>
        public ushort CanItemCount { get; set; }
        /// <summary>
        /// CAN 总线数据接收时间
        /// 第 1 条 CAN 总线数据的接收时间，hh-mm-ss-msms
        /// </summary>
        public DateTime FirstCanReceiveTime { get; set; }
        /// <summary>
        /// CAN 总线数据项
        /// </summary>
        public List<JT808CanProperty> CanItems { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="writer"></param>
        /// <param name="config"></param>
        public void Analyze(ref JT808MessagePackReader reader, Utf8JsonWriter writer, IJT808Config config)
        {
            JT808_0x0705 value = new JT808_0x0705();
            value.CanItemCount = reader.ReadUInt16();
            writer.WriteNumber($"[{value.CanItemCount.ReadNumber()}]数据项个数", value.CanItemCount);
            var dateTimeBuffer = reader.ReadVirtualArray(5).ToArray();
            value.FirstCanReceiveTime = reader.ReadDateTime_HHmmssfff();
            writer.WriteString($"[{dateTimeBuffer.ToHexString()}]CAN总线数据接收时间", value.FirstCanReceiveTime.ToString("HH-mm-ss:fff"));
            writer.WriteStartArray("CAN总线数据项");
            for (var i = 0; i < value.CanItemCount; i++)
            {
                writer.WriteStartObject();
                JT808CanProperty jT808CanProperty = new JT808CanProperty();
                jT808CanProperty.CanId = reader.ReadUInt32();
                writer.WriteNumber($"[{ jT808CanProperty.CanId.ReadNumber()}]CAN_ID", jT808CanProperty.CanId);
                jT808CanProperty.CanData = reader.ReadArray(8).ToArray();
                writer.WriteString($"CAN_数据", jT808CanProperty.CanData.ToHexString());
                if (jT808CanProperty.CanData.Length != 8)
                {
                    throw new JT808Exception(Enums.JT808ErrorCode.NotEnoughLength, $"{nameof(jT808CanProperty.CanData)}->8"); 
                }
                writer.WriteEndObject();
            }
            writer.WriteEndArray();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public JT808_0x0705 Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            JT808_0x0705 value = new JT808_0x0705();
            value.CanItemCount = reader.ReadUInt16();
            value.FirstCanReceiveTime = reader.ReadDateTime_HHmmssfff();
            value.CanItems = new List<JT808CanProperty>();
            for (var i = 0; i < value.CanItemCount; i++)
            {
                JT808CanProperty jT808CanProperty = new JT808CanProperty();
                jT808CanProperty.CanId = reader.ReadUInt32();
                jT808CanProperty.CanData = reader.ReadArray(8).ToArray();
                if (jT808CanProperty.CanData.Length != 8)
                {
                    throw new JT808Exception(Enums.JT808ErrorCode.NotEnoughLength, $"{nameof(jT808CanProperty.CanData)}->8");
                }

                jT808CanProperty.MsgGroup = jT808CanProperty.CanData[0];
                jT808CanProperty.MsgId = jT808CanProperty.CanData[1];
                jT808CanProperty.Text = ParseCANData(jT808CanProperty.CanData);

                value.CanItems.Add(jT808CanProperty);
            }
            return value;
        }

        /// <summary>
        /// 解析CAN数据为可读的文本
        /// </summary>
        /// <param name="data"></param>
        /// <returns>可读文本</returns>
        string ParseCANData(byte[] data)
        {
            Debug.Assert(data.Length == 8);

            switch (data[0])
            {
                case 0x01:
                    switch (data[1])
                    {
                        case 0x06:
                            var byte2_3 = BinaryPrimitives.ReadUInt16BigEndian(data.AsSpan(2, 2));
                            return $"VEHICLE PARKING BRAKE OFF, VEHICLE SCAN IN {byte2_3} SECONDS; BATTERY: {data[7] * 0.1:F1} VOLT";
                        default:
                            break;
                    }

                    break;
                case 0x02:
                    switch (data[1])
                    {
                        case 0x04:
                            return $"EVACUATION DRILL EXECUTION INCOMPLETE; BATTERY: {data[7] * 0.1:F1} VOLT";
                        default:
                            break;
                    }

                    break;
                case 0x03:
                    switch (data[1])
                    {
                        case 0x02:
                            return $"DRIVER INITIATED EVACUATION DRILL; BATTERY: {data[7] * 0.1:F1} VOLT";

                        // This messages is sent from LiDAS to the MDVR if LiDAS has been activated and prepares for the evacuation drill monitoring.
                        // The voltage of the main vehicle battery(12.9V) is transmitted as a single byte and calculated by dividing the value(129, dec) by 10.
                        case 0x03:
                            return $"DRIVER STARTED EVACUATION DRILL; BATTERY: {data[7] * 0.1 :F1} VOLT";

                        case 0x06:
                            var byte2_3 = BinaryPrimitives.ReadUInt16BigEndian(data.AsSpan(2, 2));
                            return $"DRIVER BUTTON PRESSED, VEHICLE SCAN IN {byte2_3} SECONDS; BATTERY: {data[7] * 0.1:F1} VOLT";

                        default:
                            break;
                    }

                    break;
                case 0x04:
                    switch (data[1])
                    {
                        // This messages is sent from LiDAS to the MDVR if LiDAS has been activated
                        // and has started to check the vehicle for children left in the vehicle.
                        // The vehicle scan will have a duration of 60 seconds and the qualifier to
                        // decide whether the vehicle is empty or not is 15 seconds.
                        // The voltage of the main vehicle battery(13.1V) is transmitted as a single byte and calculated by dividing the value(131, dec) by 10.
                        case 0x01:
                            var byte2_3 = BinaryPrimitives.ReadUInt16BigEndian(data.AsSpan(2, 2));
                            var byte4 = Convert.ToString(data[4], 2).PadLeft(8, '0');
                            var byte5 = Convert.ToString(data[5], 2).PadLeft(8, '0');
                            return $"VEHICLE SCAN INITIATED, SCAN DURATION {byte2_3} SECONDS, QUALIFIER {data[6]}, ENAB: {byte4} - {byte5}; BATTERY: {data[7] * 0.1:F1} VOLT";

                        case 0x02:
                            byte2_3 = BinaryPrimitives.ReadUInt16BigEndian(data.AsSpan(2, 2));
                            byte4 = Convert.ToString(data[4], 2).PadLeft(8, '0');
                            byte5 = Convert.ToString(data[5], 2).PadLeft(8, '0');
                            var byte6 = Convert.ToString(data[6], 2).PadLeft(8, '0');
                            var byte7 = Convert.ToString(data[7], 2).PadLeft(8, '0');
                            return $"SCAN COMPLETED, NO CHILD DETECTED, SCAN DURATION {byte2_3} SECONDS, RESP:{byte4}-{byte5}, DETD:{byte6}-{byte7}";

                        // This messages is sent from LiDAS to the MDVR after the completion of a LiDAS scan and a child has been detected.
                        // Byte 5 and 6 show the sensors responding to the CCU.
                        // Byte 7 and 8 show the sensors which detected a child
                        case 0x03:
                            byte2_3 = BinaryPrimitives.ReadUInt16BigEndian(data.AsSpan(2, 2));
                            byte4 = Convert.ToString(data[4], 2).PadLeft(8, '0');
                            byte5 = Convert.ToString(data[5], 2).PadLeft(8, '0');
                            byte6 = Convert.ToString(data[6], 2).PadLeft(8, '0');
                            byte7 = Convert.ToString(data[7], 2).PadLeft(8, '0');
                            return $"SCAN COMPLETED, CHILD DETECTED, SCAN DURATION {byte2_3} SECONDS, RESP:{byte4}-{byte5}, DETD:{byte6}-{byte7}";

                        // This messages is sent from LiDAS to the MDVR if LiDAS has completed the evacuation drill monitoring
                        // The voltage of the main vehicle battery(12.9V) is transmitted as a single byte and calculated by dividing the value(129, dec) by 10.
                        case 0x04:
                            return $"EVACUATION DRILL COMPLETED IN TIME; BATTERY: {data[7] * 0.1:F1} VOLT";

                        case 0x05:
                            return $"EVACUATION DRILL FAILED; BATTERY: {data[7] * 0.1:F1} VOLT";

                        case 0x06:
                            var byte6_7 = BinaryPrimitives.ReadUInt16BigEndian(data.AsSpan(6, 7));
                            return $"DRIVER DID NOT START EVACDRILL IN {byte6_7} SECONDS";

                        default:
                            break;
                    }

                    break;
                case 0x07:
                    switch (data[1])
                    {
                        case 0x01:
                            var byte2_3 = BinaryPrimitives.ReadUInt16BigEndian(data.AsSpan(2, 2));
                            return $"CHILD DETECTED, DRIVER AND FLEET MANAGER INFORMED, NEXT SMS IN {byte2_3} MINUTES; BATTERY: {data[7] * 0.1:F1} VOLT";

                        case 0x02:
                            byte2_3 = BinaryPrimitives.ReadUInt16BigEndian(data.AsSpan(2, 2));
                            return $"CHILD DETECTED, NO RESPONSE FROM DRIVER OR FLEET MANAGER, NEXT SMS IN {byte2_3} MINUTES; BATTERY: {data[7] * 0.1:F1} VOLT";

                        case 0x11:
                            byte2_3 = BinaryPrimitives.ReadUInt16BigEndian(data.AsSpan(2, 2));
                            return $"LOCAL LiDAS BUTTON PRESSED, VEHICLE RE-SCAN in {byte2_3} MINUTES; BATTERY: {data[7] * 0.1:F1} VOLT";

                        default:
                            break;
                    }

                    break;
                default:
                    break;
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="config"></param>
        public void Serialize(ref JT808MessagePackWriter writer, JT808_0x0705 value, IJT808Config config)
        {
            if (value.CanItems != null && value.CanItems.Count > 0)
            {
                writer.WriteUInt16((ushort)value.CanItems.Count);
                writer.WriteDateTime_HHmmssfff(value.FirstCanReceiveTime);
                foreach (var item in value.CanItems)
                {
                    writer.WriteUInt32(item.CanId);
                    if (item.CanData.Length != 8)
                    {
                        throw new JT808Exception(Enums.JT808ErrorCode.NotEnoughLength, $"{nameof(item.CanData)}->8");
                    }
                    writer.WriteArray(item.CanData);
                }
            }
        }
    }
}
