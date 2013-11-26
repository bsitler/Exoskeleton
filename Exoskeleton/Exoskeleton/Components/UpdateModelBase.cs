using Grasshopper.Kernel;
using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Exoskeleton.Components
{
    abstract class UpdateModelBase:GH_Component
    {
        public override void AppendAdditionalMenuItems(ToolStripDropDown menu)
        {
            base.AppendAdditionalMenuItems(menu);
            Menu_AppendItem(menu, "Internalize model", new System.EventHandler(InternalizeModel), true, false);
        }
        private void InternalizeModel(object sender, System.EventArgs e)
        {
        }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddPointParameter("Model center", "CP", "Model center", GH_ParamAccess.item, new Point3d(0, 0, 0));
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
        }
        protected abstract void SolveInstance(IGH_DataAccess DA)
        {

        }
        public abstract override Guid ComponentGuid { }

    }
}
