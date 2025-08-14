using Scanner.Protocol.Enums;

namespace Scanner.Protocol.Extensions
{
    /// <summary>
    /// Scanner创建包扩展
    /// </summary>
    public static partial class ScannerPackageExtensions
    {
        /// <summary>
        /// 根据消息Id创建包
        /// </summary>
        /// <typeparam name="TScannerBodies"></typeparam>
        /// <param name="msgId"></param>
        /// <param name="scannerId"></param>
        /// <param name="bodies"></param>
        /// <returns></returns>
        public static ScannerPackage Create<TScannerBodies>(this ScannerMsgId msgId, string scannerId, TScannerBodies bodies)
            where TScannerBodies : ScannerBodies
        {
            ScannerPackage scannerPackage = new ScannerPackage
            {
                Header = new ScannerHeader
                {
                    MsgId = (byte)msgId,
                    ScannerId = scannerId,
                },
                Bodies = bodies
            };
            return scannerPackage;
        }
        /// <summary>
        /// 根据消息Id创建包
        /// </summary>
        /// <param name="msgId"></param>
        /// <param name="scannerId"></param>
        /// <returns></returns>
        public static ScannerPackage Create(this ScannerMsgId msgId, string scannerId)
        {
            ScannerPackage scannerPackage = new ScannerPackage
            {
                Header = new ScannerHeader
                {
                    MsgId = (byte)msgId,
                    ScannerId = scannerId,
                }
            };
            return scannerPackage;
        }
        /// <summary>
        /// 根据自定义消息Id创建包
        /// </summary>
        /// <typeparam name="TScannerBodies"></typeparam>
        /// <param name="msgId"></param>
        /// <param name="scannerId"></param>
        /// <param name="bodies"></param>
        /// <returns></returns>
        public static ScannerPackage CreateCustomMsgId<TScannerBodies>(this byte msgId, string scannerId, TScannerBodies bodies)
            where TScannerBodies : ScannerBodies
        {
            ScannerPackage scannerPackage = new ScannerPackage
            {
                Header = new ScannerHeader
                {
                    MsgId = msgId,
                    ScannerId = scannerId
                },
                Bodies = bodies
            };
            return scannerPackage;
        }
        /// <summary>
        /// 根据自定义消息Id创建包
        /// </summary>
        /// <param name="msgId"></param>
        /// <param name="scannerId"></param>
        /// <returns></returns>
        public static ScannerPackage CreateCustomMsgId(this byte msgId, string scannerId)
        {
            ScannerPackage scannerPackage = new ScannerPackage
            {
                Header = new ScannerHeader
                {
                    MsgId = msgId,
                    ScannerId = scannerId
                }
            };
            return scannerPackage;
        }
    }
}
