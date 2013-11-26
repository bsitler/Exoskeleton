using Grasshopper.Kernel;
using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exoskeleton.Components
{
    public partial class Component_Element1D:GH_Component
    {
        internal List<Curve> geometry = new List<Curve>();
        internal string property;
        public Component_Element1D() : base("1D Element", "EL", "creates 1D element", "Exoskeleton", "GSA") { }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddCurveParameter("Curve", "C", "Creates 1D elements from line / polyline / curve", GH_ParamAccess.list);
            pManager.AddTextParameter("Property", "P", "Property integer, name or description", GH_ParamAccess.item);        
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
                 // Declare a variable for the input String
            // Use the DA object to retrieve the data inside the first input parameter.
            // If the retieval fails (for example if there is no data) we need to abort.
            if (!DA.GetDataList(0, geometry)) { return; }
            if (!DA.GetData(1, ref property)) { return; }

        }
        public override Guid ComponentGuid
        {
            get { return new Guid("{B21C29BB-872B-4079-91DD-447AA243567D}"); }
        }
    }
}
