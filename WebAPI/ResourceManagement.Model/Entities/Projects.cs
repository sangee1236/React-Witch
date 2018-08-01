using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceManagement.Model
{
    public class Projects : IEntityBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Nullable<bool> Status {get; set ;}

    }
}
