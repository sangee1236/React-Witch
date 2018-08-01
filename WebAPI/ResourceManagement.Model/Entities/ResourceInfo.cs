using System;
using System.Collections.Generic;

namespace ResourceManagement.Model
{
    public class ResourceInfo : IEntityBase
    {
        public ResourceInfo()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailID { get; set; }
        //Sangee
        public string Password { get; set; }
        public string Mobile { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime JoiningDate { get; set; }
        public string Avatar { get; set; }
        public int ResourceTypeId { get; set; }
        public int BusinessUnitId { get; set; }
        public int SystemUserId { get; set; }
        public bool Status { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }

        

    }
}
