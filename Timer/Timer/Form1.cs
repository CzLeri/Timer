using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Timer
{
    public partial class fTimer : Form
    {
        public fTimer()
        {
            InitializeComponent();
            notifyIconTimer.ContextMenuStrip = this.Menu;
        }
        public enum EXECUTION_STATE : uint
        {
            ES_AWAYMODE_REQUIRED = 0x00000040,
            ES_CONTINUOUS = 0x80000000,
            ES_DISPLAY_REQUIRED = 0x00000002,
            ES_SYSTEM_REQUIRED = 0x00000001
            // Legacy flag, should not be used.
            // ES_USER_PRESENT = 0x00000004
        }


        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern uint SetThreadExecutionState(EXECUTION_STATE esFlags);
        private void KeepAlive()
        {
            SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED | EXECUTION_STATE.ES_SYSTEM_REQUIRED | EXECUTION_STATE.ES_CONTINUOUS);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tHide_Tick(object sender, EventArgs e)
        {
            Hide();
            tHide.Enabled = false;
        }

        private void tBlock_Tick(object sender, EventArgs e)
        {
            KeepAlive();
        }
    }
}
