using EPDM.Interop.epdm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SolidWorksPDMPropertyFiddler
{
    [Guid("F28DF6F0-EB05-491A-B484-32F481B289B7"), ComVisible(true)]
    public class HookSetup : IEdmAddIn5
    {
        private EdmVault5 thisVault;
        private IEdmVault8 thisVaultV8;
        private IWin32Window parentWnd;


        ObservableCollection<string> fileList;
        public void GetAddInInfo(ref EdmAddInInfo poInfo, IEdmVault5 poVault, IEdmCmdMgr5 poCmdMgr)
        {

            try
            {
                //Información miscelanea del add-in
                poInfo.mbsAddInName = "PropertyFiddler";
                poInfo.mbsCompany = "ADDR";
                poInfo.mbsDescription = string.Format("Batch property setup");
                poInfo.mlAddInVersion = 2;
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
            try
            {
                if (poCmd.meCmdType == EdmCmdType.EdmCmd_Menu)
                {
                    fileList= new ObservableCollection<string>();

                    //enableDebugger();
                    MessageBox.Show("Elegiste el menu");
                    string fileName;
                    for (int i = 0; i < ppoData.Length; i++)
                    {
                        fileName = ppoData[i].mbsStrData1;
                        fileList.Add(Path.GetFileName(fileName));
                    }
                }
                UI miVentana = new UI();
                
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           

        }

        #region Métodos privados
        private void enableDebugger()
        {
            MessageBox.Show(String.Format(" Attach debugger to process {0} (ID: {1})", System.Diagnostics.Process.GetCurrentProcess().ProcessName, System.Diagnostics.Process.GetCurrentProcess().Id));
        }
        private bool isAdminLogged()
        {
            IEdmUserMgr5 userMgr = default(IEdmUserMgr5);
            IEdmUser5 usuario = default(IEdmUser5);

            userMgr = (IEdmUserMgr5)thisVault;
            usuario = userMgr.GetLoggedInUser();

            return string.Equals(usuario.Name, "admin", StringComparison.OrdinalIgnoreCase);

        }

        #endregion
    }
}




