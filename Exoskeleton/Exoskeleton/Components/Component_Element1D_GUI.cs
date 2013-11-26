using Grasshopper.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Exoskeleton.Components
{
    public partial class Component_Element1D:GH_Component
    {
        private bool include;
        public override void AddedToDocument(GH_Document document)
        {
            base.AddedToDocument(document);
            this.UpdateMessage();
        }
        public override void AppendAdditionalMenuItems(ToolStripDropDown menu)
        {
            base.AppendAdditionalMenuItems(menu);
            Menu_AppendItem(menu, "Include in GSA Export", new System.EventHandler(this.Menu_IncludeClicked), true, true);
        }
        private void Menu_IncludeClicked(object sender, System.EventArgs e)
        {
            this.include = !this.include;
            this.UpdateMessage();
            this.ExpireSolution(true);
        }
        private void UpdateMessage()
        {
            if (include) this.Message = "included";
            else this.Message = "excluded";
        }
    }
}
