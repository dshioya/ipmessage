using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ipmessage
{
    class RecieveServer
    {

        private bool looping;

        public void start()
        {
            looping = true;

            Thread t = new Thread(new ThreadStart(this.task));
            t.IsBackground = true;
            t.Start();
        }

        public void stop()
        {
            looping = false;
        }

        private void task()
        {
            while (looping)
            {
                MessageBox.Show("");

                Thread.Sleep(10000);
            }
        }
    }


}
