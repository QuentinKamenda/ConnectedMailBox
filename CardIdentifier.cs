/*
	TUIO C# Example - part of the "Connected Casino Table" project

    by Quentin KAMENDA
    for ISEN Lille

    23/05/2017

    Copyright (c) 2005-2014 Martin Kaltenbrunner <martin@tuio.org>

*/

using System;
using TUIO;

	public class CardIdentifier : TuioListener
	{

    #region Card
    /* Card detection */

        public void addTuioObject(TuioObject tobj)
        /* A new object appears on the screen*/
        {
			Console.WriteLine("add card "+tobj.SymbolID+" "+tobj.SessionID+" "+tobj.X+" "+tobj.Y);
                                       //   real ID,    Session ID,     X position,     Y position 
		}

		public void updateTuioObject(TuioObject tobj)
        /* An object moves */
        {
			Console.WriteLine("set card "+tobj.SymbolID+" "+tobj.SessionID+" "+tobj.X+" "+tobj.Y);
                                       //   real ID,    Session ID,     X position,     Y position 
        }

        public void removeTuioObject(TuioObject tobj)
        /* An object disappears from the scrren */
        {
			Console.WriteLine("del card "+tobj.SymbolID+" "+tobj.SessionID);
                                       //   real ID,    Session ID,     X position,     Y position 
        }
    #endregion

    #region Cursor
    /* USELESS FOR US */

    public void addTuioCursor(TuioCursor tcur) {
                Console.WriteLine("add cur "+tcur.CursorID + " ("+tcur.SessionID+") "+tcur.X+" "+tcur.Y);
            }

            public void updateTuioCursor(TuioCursor tcur) {
                Console.WriteLine("set cur "+tcur.CursorID + " ("+tcur.SessionID+") "+tcur.X+" "+tcur.Y+" "+tcur.MotionSpeed+" "+tcur.MotionAccel);
            }

            public void removeTuioCursor(TuioCursor tcur) {
                Console.WriteLine("del cur "+tcur.CursorID + " ("+tcur.SessionID+")");
            }

    #endregion

    #region Blob
    /* USELESS FOR US */

    public void addTuioBlob(TuioBlob tblb) {
                Console.WriteLine("add blb "+tblb.BlobID + " ("+tblb.SessionID+") "+tblb.X+" "+tblb.Y+" "+tblb.Angle+" "+tblb.Width+" "+tblb.Height+" "+tblb.Area);
            }

            public void updateTuioBlob(TuioBlob tblb) {
                Console.WriteLine("set blb "+tblb.BlobID + " ("+tblb.SessionID+") "+tblb.X+" "+tblb.Y+" "+tblb.Angle+" "+tblb.Width+" "+tblb.Height+" "+tblb.Area+" "+tblb.MotionSpeed+" "+tblb.RotationSpeed+" "+tblb.MotionAccel+" "+tblb.RotationAccel);
            }

            public void removeTuioBlob(TuioBlob tblb) {
                Console.WriteLine("del blb "+tblb.BlobID + " ("+tblb.SessionID+")");
            }
    
    #endregion

    public void refresh(TuioTime frameTime)
        /* refresh function */
        {
			//Console.WriteLine("refresh "+frameTime.getTotalMilliseconds(200));
		}


		public static void Main(String[] argv)
        /* main function */
        {
			CardIdentifier demo = new CardIdentifier();
			TuioClient client = null;

			switch (argv.Length) {
				case 1:
					int port = 0;
					port = int.Parse(argv[0],null);
					if(port>0) client = new TuioClient(port);
					break;
				case 0:
					client = new TuioClient();
					break;
			}

			if (client!=null) {
				client.addTuioListener(demo);
				client.connect();
				Console.WriteLine("listening to TUIO messages at port " + client.getPort());

			} else Console.WriteLine("usage: java CardIdentifier [port]");
		}
	}
