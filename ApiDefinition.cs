                                                                       using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Redpark
{
	[BaseType (typeof (NSObject))]
	interface RscMgr {

		//- (void) setDelegate:(id <RscMgrDelegate>) delegate;
		[Export ("setDelegate:")]
		void SetDelegate (NSObject delegate1);
		
		//- (void) open;
		[Export ("open")]
		void Open ();

		//- (void) setBaud:(int)baud;
		[Export ("setBaud:")]
		void SetBaud (int baud);
		
		//- (void) setDataSize:(DataSizeType)dataSize;
		[Export ("setDataSize:")]
		void SetDataSize (DataSizeType dataSize);

		//- (void) setParity:(ParityType)parity;
		[Export ("setParity:")]
		void SetParity (ParityType parity);

		//- (void) setStopBits:(StopBitsType)stopBits;
		[Export ("setStopBits:")]
		void SetStopBits (StopBitsType stopBits);
		 
		//- (int) write:(UInt8 *)data Length:(UInt32)length;
		[Export ("write:Length:")]
		int Write (IntPtr data, UInt32 length);

		//- (int) read:(UInt8 *)data Length:(UInt32)length;
		[Export ("read:Length:")]
		int Read (IntPtr data, UInt32 length);

		//- (int) getReadBytesAvailable;
		[Export ("getReadBytesAvailable")]
		int GetReadBytesAvailable { get; }

		//- (int) getModemStatus;
		[Export ("getModemStatus")]
		int GetModemStatus { get; }

		//- (BOOL) getDtr;
		[Export ("getDtr")]
		bool GetDtr { get; }

		//- (BOOL) getRts;
		[Export ("getRts")]
		bool GetRts { get; }

		//- (void) setDtr:(BOOL)enable;
		[Export ("setDtr:")]
		void SetDtr (bool enable);

		//- (void) setRts:(BOOL)enable;
		[Export ("setRts:")]
		void SetRts (bool enable);
		/*
		//- (void) setPortConfig:(serialPortConfig *)config RequestStatus:(BOOL)reqStatus;
		[Export ("setPortConfig:RequestStatus:")]
		void SetPortConfig (serialPortConfig config, bool reqStatus);

		//- (void) setPortControl:(serialPortControl *)control RequestStatus:(BOOL)reqStatus;
		[Export ("setPortControl:RequestStatus:")]
		void SetPortControl (serialPortControl control, bool reqStatus);

		//- (void) getPortConfig:(serialPortConfig *) portConfig;
		[Export ("getPortConfig:")]
		void GetPortConfig (serialPortConfig portConfig);

		//- (void) getPortStatus:(serialPortStatus *) portStatus;
		[Export ("getPortStatus:")]
		void GetPortStatus (serialPortStatus portStatus);
		 */
		//- (int) writeRscMessage:(int)cmd Length:(int)len MsgData:(UInt8 *)msgData;
		[Export ("writeRscMessage:Length:MsgData:")]
		int WriteRscMessage (int cmd, int len, IntPtr msgData);

		//- (void) testGpsCable;
		[Export ("testGpsCable")]
		void TestGpsCable ();

	}
	
	[Model]
	[BaseType(typeof(NSObject))]
	public interface RscMgrDelegate
	{
		// Redpark Serial Cable has been connected and/or application moved to foreground.
		// protocol is the string which matched from the protocol list passed to initWithProtocol:
		// - (void) cableConnected:(NSString *)protocol;
		[Abstract, Export("cableConnected:")]
		void CableConnected(string protocol);

        [Abstract, Export ("cableDisconnected")]
        void CableDisconnected ();
		
		[Abstract, Export("portStatusChanged")]
		void PortStatusChanged();

        [Abstract, Export ("readBytesAvailable:")]
        void ReadBytesAvailable (int len);

        [Export ("didReceivePortConfig")]
        void DidReceivePortConfig ();

        [Export ("didGpsLoopTest:")]
        void DidGpsLoopTest (bool pass);
	}
}