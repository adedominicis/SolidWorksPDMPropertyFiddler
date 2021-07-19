using EPDM.Interop.epdm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolidWorksPDMPropertyFiddler
{
    [Guid("F28DF6F0-EB05-491A-B484-32F481B289B7"), ComVisible(true)]
    public class HookSetup : IEdmAddIn5
    {
        private EdmVault5 thisVault;
        private IEdmVault8 thisVaultV8;
        private IWin32Window parentWnd;
        public void GetAddInInfo(ref EdmAddInInfo poInfo, IEdmVault5 poVault, IEdmCmdMgr5 poCmdMgr)
        {
            //MessageBox.Show(String.Format(" Attach debugger to process {0} (ID: {1})", System.Diagnostics.Process.GetCurrentProcess().ProcessName, System.Diagnostics.Process.GetCurrentProcess().Id));
            try
            {
                //Información miscelanea del add-in
                poInfo.mbsAddInName = "PropertyFiddler";
                poInfo.mbsCompany = "ADDR";
                poInfo.mbsDescription = string.Format("Batch property setup");
                poInfo.mlAddInVersion = 1;
                poInfo.mlRequiredVersionMajor = 5;
                poInfo.mlRequiredVersionMinor = 2;

                // Hook para un comando, usado en testing
                poCmdMgr.AddCmd(1, "Batch edit properties", (int)EdmMenuFlags.EdmMenu_Nothing);

            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show("(GetAddInInfo) HRESULT = 0x" + ex.ErrorCode.ToString("X") + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void OnCmd(ref EdmCmd poCmd, ref EdmCmdData[] ppoData)
        {
            MessageBox.Show("You clicked!");
        }
    }
}




