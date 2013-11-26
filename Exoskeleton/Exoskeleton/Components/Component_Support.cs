using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grasshopper.Kernel;
using Rhino.Geometry;

namespace Exoskeleton.Components
{
    public partial class Component_Support: GH_Component 
    {
        private bool[] restraint = new bool[] { true, true, true, false, false, false };
        internal List<Point3d> nodes;
     
        public Component_Support(): base("Support", "Sup", "Creates nodal restraints and supports", "Exoskeleton", "GSA"){}
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddPointParameter("Points", "P", "Creates nodal support conditions", GH_ParamAccess.list);
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // Use the DA object to retrieve the data inside the first input parameter.
            // If the retieval fails (for example if there is no data) we need to abort.
            if (!DA.GetDataList(0, nodes)) { return; }
        }

        public override Guid ComponentGuid
        {
            get { return new Guid("{8F70F5FE-A92C-423E-91BF-8BB8F3582C79}");}
        }
    }
}
