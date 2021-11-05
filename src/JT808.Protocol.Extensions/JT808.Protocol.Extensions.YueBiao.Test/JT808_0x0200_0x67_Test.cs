using JT808.Protocol.Extensions.YueBiao.MessageBody;
using JT808.Protocol.MessageBody;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Xunit;

namespace JT808.Protocol.Extensions.YueBiao.Test
{
    public class JT808_0x0200_0x67_Test
    {
        JT808Serializer JT808Serializer;
        public JT808_0x0200_0x67_Test()
        {
            ServiceCollection serviceDescriptors = new ServiceCollection();
            serviceDescriptors.AddJT808Configure()
                                        .AddYueBiaoConfigure();
            IJT808Config jT808Config = serviceDescriptors.BuildServiceProvider().GetRequiredService<IJT808Config>();
            JT808Serializer = new JT808Serializer(jT808Config);
        }
        [Fact]
        public void Serializer()
        {
            JT808_0x0200 jT808UploadLocationRequest = new JT808_0x0200
            {
                AlarmFlag = 1,
                Altitude = 40,
                GPSTime = DateTime.Parse("2018-07-15 10:10:10"),
                Lat = 12222222,
                Lng = 132444444,
                Speed = 60,
                Direction = 0,
                StatusFlag = 2,
                BasicLocationAttachData = new Dictionary<byte, JT808_0x0200_BodyBase>()
            };
            jT808UploadLocationRequest.BasicLocationAttachData.Add(JT808_YueBiao_Constants.JT808_0X0200_0x67, new JT808_0x0200_0x67
            {
                AlarmId = 1,
                AlarmIdentification = new Metadata.AlarmIdentificationProperty
                {
                    AttachCount = 2,
                    SN = 3,
                     TerminalId = "4444444",
                    Time = Convert.ToDateTime("2019-12-10 18:31:00"),
                     Retain1=5, 
                      Retain2=6 
                },
                AlarmTime = Convert.ToDateTime("2019-12-11 18:31:00"),
                Altitude = 7,
                AlarmOrEventType = 9,
                FlagState = 12, 
                Latitude = 13,
                Longitude = 14,
                Speed = 17,
                VehicleState = 19
            });
            var hex = JT808Serializer.Serialize(jT808UploadLocationRequest).ToHexString();
            Assert.Equal("000000010000000200BA7F0E07E4F11C0028003C00001807151010106741000000010C091100070000000D0000000E191211183100001334343434343434000000000000000000000000000000000000000000000019121018310003020506", hex);
        }
        [Fact]
        public void Deserialize()
        {
            var jT808UploadLocationRequest = JT808Serializer.Deserialize<JT808_0x0200>("000000010000000200BA7F0E07E4F11C0028003C00001807151010106741000000010C091100070000000D0000000E191211183100001334343434343434000000000000000000000000000000000000000000000019121018310003020506".ToHexBytes());
            jT808UploadLocationRequest.BasicLocationAttachData.TryGetValue(JT808_YueBiao_Constants.JT808_0X0200_0x67, out var value);
            JT808_0x0200_0x67 jT808_0X0200_0X67 = value as JT808_0x0200_0x67;
            Assert.Equal(1u, jT808_0X0200_0X67.AlarmId);
            Assert.Equal(2, jT808_0X0200_0X67.AlarmIdentification.AttachCount);
            Assert.Equal(3, jT808_0X0200_0X67.AlarmIdentification.SN);
            Assert.Equal("4444444", jT808_0X0200_0X67.AlarmIdentification.TerminalId);
            Assert.Equal(5, jT808_0X0200_0X67.AlarmIdentification.Retain1);
            Assert.Equal(6, jT808_0X0200_0X67.AlarmIdentification.Retain2);
            Assert.Equal(Convert.ToDateTime("2019-12-10 18:31:00"), jT808_0X0200_0X67.AlarmIdentification.Time);
            Assert.Equal(Convert.ToDateTime("2019-12-11 18:31:00"), jT808_0X0200_0X67.AlarmTime);
            Assert.Equal(7, jT808_0X0200_0X67.Altitude);
            Assert.Equal(9, jT808_0X0200_0X67.AlarmOrEventType);
            Assert.Equal(0x67, jT808_0X0200_0X67.AttachInfoId);
            Assert.Equal(65, jT808_0X0200_0X67.AttachInfoLength);
            Assert.Equal(12, jT808_0X0200_0X67.FlagState);
            Assert.Equal(13, jT808_0X0200_0X67.Latitude);
            Assert.Equal(14, jT808_0X0200_0X67.Longitude);
            Assert.Equal(17, jT808_0X0200_0X67.Speed);
            Assert.Equal(19, jT808_0X0200_0X67.VehicleState);
        }
        [Fact]
        public void Json()
        {
            var json = JT808Serializer.Analyze<JT808_0x0200>("000000010000000200BA7F0E07E4F11C0028003C00001807151010106741000000010C091100070000000D0000000E191211183100001334343434343434000000000000000000000000000000000000000000000019121018310003020506".ToHexBytes());
        }
    }
}
