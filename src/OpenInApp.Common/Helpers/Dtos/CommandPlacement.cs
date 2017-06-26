namespace OpenInApp.Common.Helpers.Dtos
{
    /// <summary>
    /// https://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.vsmenus.idm_vs_ctxt_projnode.aspx
    /// https://blogs.msdn.microsoft.com/martintracy/2006/05/16/common-context-menu-constants/
    /// </summary>
    public enum CommandPlacement
    {
        IDM_VS_CTXT_CODEWIN,//Code editor
        IDM_VS_CTXT_FOLDERNODE,//Folder selected
        IDM_VS_CTXT_ITEMNODE,//File selected
        IDM_VS_CTXT_PROJNODE,//Project selected
        //IDM_VS_CTXT_XPROJ_MULTIPROJ,//applies when the current selection consists of multiple root project nodes only. 
        //IDM_VS_CTXT_XPROJ_PROJITEM,//applies when the current selection contains a mix of root project node(s) and project item(s). In addition, the selection may or may not contain the solution node. 
        //IDM_VS_CTXT_XPROJ_MULTIITEM,//applies when the current selection contains project items from multiple projects within the solution, or when items of different types are selected within the same project. 
    }
}
