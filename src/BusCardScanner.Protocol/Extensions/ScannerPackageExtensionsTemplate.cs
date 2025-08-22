using Scanner.Protocol.Enums;

namespace Scanner.Protocol.Extensions
{
    /// <summary>
    /// todo:source-generators正式发布以后将T4模板换掉
    /// https://devblogs.microsoft.com/dotnet/introducing-c-source-generators/
    /// </summary>
	public static partial class ScannerPackageExtensions
	{
			/// <summary>
			/// 0x01 - 读卡器通用应答
			/// auto-generated
			/// </summary>
			public static ScannerPackage Create_读卡器通用应答(this ScannerMsgId msgId, string scannerId, Scanner.Protocol.MessageBody.Scanner_0x01 bodies)
			{
				return Create<Scanner.Protocol.MessageBody.Scanner_0x01>(msgId, scannerId, bodies);
			}

			/// <summary>
			/// 0x01 - 读卡器通用应答
			/// auto-generated
			/// </summary>
			public static ScannerPackage Create(this ScannerMsgId msgId, string scannerId, Scanner.Protocol.MessageBody.Scanner_0x01 bodies)
			{
				return Create<Scanner.Protocol.MessageBody.Scanner_0x01>(msgId, scannerId, bodies);
			}
			/// <summary>
			/// 0x02 - 读卡器启动通知
			/// auto-generated
			/// </summary>
			public static ScannerPackage Create_读卡器启动通知(this ScannerMsgId msgId, string scannerId, Scanner.Protocol.MessageBody.Scanner_0x02 bodies)
			{
				return Create<Scanner.Protocol.MessageBody.Scanner_0x02>(msgId, scannerId, bodies);
			}

			/// <summary>
			/// 0x02 - 读卡器启动通知
			/// auto-generated
			/// </summary>
			public static ScannerPackage Create(this ScannerMsgId msgId, string scannerId, Scanner.Protocol.MessageBody.Scanner_0x02 bodies)
			{
				return Create<Scanner.Protocol.MessageBody.Scanner_0x02>(msgId, scannerId, bodies);
			}
			/// <summary>
			/// 0x03 - 刷卡事件通知
			/// auto-generated
			/// </summary>
			public static ScannerPackage Create_刷卡事件通知(this ScannerMsgId msgId, string scannerId, Scanner.Protocol.MessageBody.Scanner_0x03 bodies)
			{
				return Create<Scanner.Protocol.MessageBody.Scanner_0x03>(msgId, scannerId, bodies);
			}

			/// <summary>
			/// 0x03 - 刷卡事件通知
			/// auto-generated
			/// </summary>
			public static ScannerPackage Create(this ScannerMsgId msgId, string scannerId, Scanner.Protocol.MessageBody.Scanner_0x03 bodies)
			{
				return Create<Scanner.Protocol.MessageBody.Scanner_0x03>(msgId, scannerId, bodies);
			}
			/// <summary>
			/// 0x04 - 读取读卡器密钥应答
			/// auto-generated
			/// </summary>
			public static ScannerPackage Create_读取读卡器密钥应答(this ScannerMsgId msgId, string scannerId, Scanner.Protocol.MessageBody.Scanner_0x04 bodies)
			{
				return Create<Scanner.Protocol.MessageBody.Scanner_0x04>(msgId, scannerId, bodies);
			}

			/// <summary>
			/// 0x04 - 读取读卡器密钥应答
			/// auto-generated
			/// </summary>
			public static ScannerPackage Create(this ScannerMsgId msgId, string scannerId, Scanner.Protocol.MessageBody.Scanner_0x04 bodies)
			{
				return Create<Scanner.Protocol.MessageBody.Scanner_0x04>(msgId, scannerId, bodies);
			}
			/// <summary>
			/// 0x05 - 读取读卡器工作状态应答
			/// auto-generated
			/// </summary>
			public static ScannerPackage Create_读取读卡器工作状态应答(this ScannerMsgId msgId, string scannerId, Scanner.Protocol.MessageBody.Scanner_0x05 bodies)
			{
				return Create<Scanner.Protocol.MessageBody.Scanner_0x05>(msgId, scannerId, bodies);
			}

			/// <summary>
			/// 0x05 - 读取读卡器工作状态应答
			/// auto-generated
			/// </summary>
			public static ScannerPackage Create(this ScannerMsgId msgId, string scannerId, Scanner.Protocol.MessageBody.Scanner_0x05 bodies)
			{
				return Create<Scanner.Protocol.MessageBody.Scanner_0x05>(msgId, scannerId, bodies);
			}
			/// <summary>
			/// 0x06 - 升级结果通知
			/// auto-generated
			/// </summary>
			public static ScannerPackage Create_升级结果通知(this ScannerMsgId msgId, string scannerId, Scanner.Protocol.MessageBody.Scanner_0x06 bodies)
			{
				return Create<Scanner.Protocol.MessageBody.Scanner_0x06>(msgId, scannerId, bodies);
			}

			/// <summary>
			/// 0x06 - 升级结果通知
			/// auto-generated
			/// </summary>
			public static ScannerPackage Create(this ScannerMsgId msgId, string scannerId, Scanner.Protocol.MessageBody.Scanner_0x06 bodies)
			{
				return Create<Scanner.Protocol.MessageBody.Scanner_0x06>(msgId, scannerId, bodies);
			}
			/// <summary>
			/// 0x08 - 读取刷卡最小时间间隔应答
			/// auto-generated
			/// </summary>
			public static ScannerPackage Create_读取刷卡最小时间间隔应答(this ScannerMsgId msgId, string scannerId, Scanner.Protocol.MessageBody.Scanner_0x08 bodies)
			{
				return Create<Scanner.Protocol.MessageBody.Scanner_0x08>(msgId, scannerId, bodies);
			}

			/// <summary>
			/// 0x08 - 读取刷卡最小时间间隔应答
			/// auto-generated
			/// </summary>
			public static ScannerPackage Create(this ScannerMsgId msgId, string scannerId, Scanner.Protocol.MessageBody.Scanner_0x08 bodies)
			{
				return Create<Scanner.Protocol.MessageBody.Scanner_0x08>(msgId, scannerId, bodies);
			}
			/// <summary>
			/// 0x81 - 平台通用应答
			/// auto-generated
			/// </summary>
			public static ScannerPackage Create_平台通用应答(this ScannerMsgId msgId, string scannerId, Scanner.Protocol.MessageBody.Scanner_0x81 bodies)
			{
				return Create<Scanner.Protocol.MessageBody.Scanner_0x81>(msgId, scannerId, bodies);
			}

			/// <summary>
			/// 0x81 - 平台通用应答
			/// auto-generated
			/// </summary>
			public static ScannerPackage Create(this ScannerMsgId msgId, string scannerId, Scanner.Protocol.MessageBody.Scanner_0x81 bodies)
			{
				return Create<Scanner.Protocol.MessageBody.Scanner_0x81>(msgId, scannerId, bodies);
			}
			/// <summary>
			/// 0x82 - 设置读卡器时间
			/// auto-generated
			/// </summary>
			public static ScannerPackage Create_设置读卡器时间(this ScannerMsgId msgId, string scannerId, Scanner.Protocol.MessageBody.Scanner_0x82 bodies)
			{
				return Create<Scanner.Protocol.MessageBody.Scanner_0x82>(msgId, scannerId, bodies);
			}

			/// <summary>
			/// 0x82 - 设置读卡器时间
			/// auto-generated
			/// </summary>
			public static ScannerPackage Create(this ScannerMsgId msgId, string scannerId, Scanner.Protocol.MessageBody.Scanner_0x82 bodies)
			{
				return Create<Scanner.Protocol.MessageBody.Scanner_0x82>(msgId, scannerId, bodies);
			}
			/// <summary>
			/// 0x83 - 设置读卡器密钥
			/// auto-generated
			/// </summary>
			public static ScannerPackage Create_设置读卡器密钥(this ScannerMsgId msgId, string scannerId, Scanner.Protocol.MessageBody.Scanner_0x83 bodies)
			{
				return Create<Scanner.Protocol.MessageBody.Scanner_0x83>(msgId, scannerId, bodies);
			}

			/// <summary>
			/// 0x83 - 设置读卡器密钥
			/// auto-generated
			/// </summary>
			public static ScannerPackage Create(this ScannerMsgId msgId, string scannerId, Scanner.Protocol.MessageBody.Scanner_0x83 bodies)
			{
				return Create<Scanner.Protocol.MessageBody.Scanner_0x83>(msgId, scannerId, bodies);
			}
			/// <summary>
			/// 0x84 - 读取读卡器密钥
			/// auto-generated
			/// </summary>
			public static ScannerPackage Create_读取读卡器密钥(this ScannerMsgId msgId, string scannerId, Scanner.Protocol.MessageBody.Scanner_0x84 bodies)
			{
				return Create<Scanner.Protocol.MessageBody.Scanner_0x84>(msgId, scannerId, bodies);
			}

			/// <summary>
			/// 0x84 - 读取读卡器密钥
			/// auto-generated
			/// </summary>
			public static ScannerPackage Create(this ScannerMsgId msgId, string scannerId, Scanner.Protocol.MessageBody.Scanner_0x84 bodies)
			{
				return Create<Scanner.Protocol.MessageBody.Scanner_0x84>(msgId, scannerId, bodies);
			}
			/// <summary>
			/// 0x85 - 读取读卡器工作状态
			/// auto-generated
			/// </summary>
			public static ScannerPackage Create_读取读卡器工作状态(this ScannerMsgId msgId, string scannerId, Scanner.Protocol.MessageBody.Scanner_0x85 bodies)
			{
				return Create<Scanner.Protocol.MessageBody.Scanner_0x85>(msgId, scannerId, bodies);
			}

			/// <summary>
			/// 0x85 - 读取读卡器工作状态
			/// auto-generated
			/// </summary>
			public static ScannerPackage Create(this ScannerMsgId msgId, string scannerId, Scanner.Protocol.MessageBody.Scanner_0x85 bodies)
			{
				return Create<Scanner.Protocol.MessageBody.Scanner_0x85>(msgId, scannerId, bodies);
			}
			/// <summary>
			/// 0x86 - 固件升级
			/// auto-generated
			/// </summary>
			public static ScannerPackage Create_固件升级(this ScannerMsgId msgId, string scannerId, Scanner.Protocol.MessageBody.Scanner_0x86 bodies)
			{
				return Create<Scanner.Protocol.MessageBody.Scanner_0x86>(msgId, scannerId, bodies);
			}

			/// <summary>
			/// 0x86 - 固件升级
			/// auto-generated
			/// </summary>
			public static ScannerPackage Create(this ScannerMsgId msgId, string scannerId, Scanner.Protocol.MessageBody.Scanner_0x86 bodies)
			{
				return Create<Scanner.Protocol.MessageBody.Scanner_0x86>(msgId, scannerId, bodies);
			}
			/// <summary>
			/// 0x87 - 设置刷卡最小时间间隔
			/// auto-generated
			/// </summary>
			public static ScannerPackage Create_设置刷卡最小时间间隔(this ScannerMsgId msgId, string scannerId, Scanner.Protocol.MessageBody.Scanner_0x87 bodies)
			{
				return Create<Scanner.Protocol.MessageBody.Scanner_0x87>(msgId, scannerId, bodies);
			}

			/// <summary>
			/// 0x87 - 设置刷卡最小时间间隔
			/// auto-generated
			/// </summary>
			public static ScannerPackage Create(this ScannerMsgId msgId, string scannerId, Scanner.Protocol.MessageBody.Scanner_0x87 bodies)
			{
				return Create<Scanner.Protocol.MessageBody.Scanner_0x87>(msgId, scannerId, bodies);
			}
			/// <summary>
			/// 0x88 - 读取刷卡最小时间间隔
			/// auto-generated
			/// </summary>
			public static ScannerPackage Create_读取刷卡最小时间间隔(this ScannerMsgId msgId, string scannerId, Scanner.Protocol.MessageBody.Scanner_0x88 bodies)
			{
				return Create<Scanner.Protocol.MessageBody.Scanner_0x88>(msgId, scannerId, bodies);
			}

			/// <summary>
			/// 0x88 - 读取刷卡最小时间间隔
			/// auto-generated
			/// </summary>
			public static ScannerPackage Create(this ScannerMsgId msgId, string scannerId, Scanner.Protocol.MessageBody.Scanner_0x88 bodies)
			{
				return Create<Scanner.Protocol.MessageBody.Scanner_0x88>(msgId, scannerId, bodies);
			}
	}
}