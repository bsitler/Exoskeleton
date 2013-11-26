using Grasshopper.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Exoskeleton.Components
{
    public partial class Component_Support : GH_Component
    {
        private readonly bool[] res_free = new bool[] { false, false, false, false, false, false };
        private readonly bool[] res_pinned = new bool[] { true, true, true, false, false, false };
        private readonly bool[] res_roller = new bool[] { false, false, true, false, false, false };
        private readonly bool[] res_fixed = new bool[] { true, true, true, true, true, true };

        public override void AddedToDocument(GH_Document document)
        {
            base.AddedToDocument(document);
            this.UpdateMessage();
        }
        public override void AppendAdditionalMenuItems(ToolStripDropDown menu)
        {
            base.AppendAdditionalMenuItems(menu);
            Menu_AppendItem(menu, "X", new System.EventHandler(this.Menu_XClicked), true, restraint[0]);
            Menu_AppendItem(menu, "Y", new System.EventHandler(this.Menu_YClicked), true, restraint[1]);
            Menu_AppendItem(menu, "Z", new System.EventHandler(this.Menu_ZClicked), true, restraint[2]);
            Menu_AppendItem(menu, "XX", new System.EventHandler(this.Menu_XXClicked), true, restraint[3]);
            Menu_AppendItem(menu, "YY", new System.EventHandler(this.Menu_YYClicked), true, restraint[4]);
            Menu_AppendItem(menu, "ZZ", new System.EventHandler(this.Menu_ZZClicked), true, restraint[5]);
        }
        private void Menu_XClicked(object sender, System.EventArgs e)
        {
            this.restraint[0] = !this.restraint[0];
            this.UpdateMessage();
            this.ExpireSolution(true);
        }
        private void Menu_YClicked(object sender, System.EventArgs e)
        {
            this.restraint[1] = !this.restraint[1];
            this.UpdateMessage();
            this.ExpireSolution(true);
        }
        private void Menu_ZClicked(object sender, System.EventArgs e)
        {
            this.restraint[2] = !this.restraint[2];
            this.UpdateMessage();
            this.ExpireSolution(true);
        }
        private void Menu_XXClicked(object sender, System.EventArgs e)
        {
            this.restraint[3] = !this.restraint[3];
            this.UpdateMessage();
            this.ExpireSolution(true);
        }
        private void Menu_YYClicked(object sender, System.EventArgs e)
        {
            this.restraint[4] = !this.restraint[4];
            this.UpdateMessage();
            this.ExpireSolution(true);
        }
        private void Menu_ZZClicked(object sender, System.EventArgs e)
        {
            this.restraint[5] = !this.restraint[5];
            this.UpdateMessage();
            this.ExpireSolution(true);
        }

        private void UpdateMessage()
        {
            if (this.restraint.SequenceEqual(res_free)) { this.Message = "Free"; }
            else if (this.restraint.SequenceEqual(res_pinned)) { this.Message = "Pinned"; }
            else if (this.restraint.SequenceEqual(res_roller)) { this.Message = "Roller"; }
            else if (this.restraint.SequenceEqual(res_fixed)) { this.Message = "Fixed"; }
            else { this.Message = BuildMessage(); }
        }
        private string BuildMessage()
        {
            StringBuilder message = new StringBuilder();
            if (restraint[0]) message.Append("X");
            if (restraint[1]) message.Append("Y");
            if (restraint[2]) message.Append("Z");
            if (message.Length > 0) message.Append(" ");
            if (restraint[3]) message.Append("XX");
            if (restraint[4]) message.Append("YY");
            if (restraint[5]) message.Append("ZZ");
            return message.ToString().TrimEnd(new char[] { ' ' });
        }
    }
}
