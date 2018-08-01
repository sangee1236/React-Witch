using ResourceManagement.Model;
using System;
using System.Linq;

namespace ResourceManagement.Data
{
    /// <summary>
    /// Populates the table with predefined data
    /// </summary>
    public class ResourceManagementDbInitializer
    {
        private static ResourceManagementContext context;
        public static void Initialize(IServiceProvider serviceProvider)
        {
            context = (ResourceManagementContext)serviceProvider.GetService(typeof(ResourceManagementContext));

            InitializeResources();
        }

        private static void InitializeResources()
        {
            //if (!context.Resources.Any())
            //{
            //    //dummy data
            //    ResourceInfo user_01 = new ResourceInfo { Name = "Chris Sakellarios", Status = true, Avatar = "avatar_02.png" };

            //    ResourceInfo user_02 = new ResourceInfo { Name = "Charlene Campbell", Status = false, Avatar = "avatar_03.jpg" };

            //    ResourceInfo user_03 = new ResourceInfo { Name = "Mattie Lyons", Status = true, Avatar = "avatar_05.png" };

            //    ResourceInfo user_04 = new ResourceInfo { Name = "Kelly Alvarez", Status = true, Avatar = "avatar_01.png" };

            //    ResourceInfo user_05 = new ResourceInfo { Name = "Charlie Cox", Status = true, Avatar = "avatar_03.jpg" };

            //    ResourceInfo user_06 = new ResourceInfo { Name = "Megan	Fox", Status = true, Avatar = "avatar_05.png" };

            //    context.Resources.Add(user_01);
            //    context.Resources.Add(user_02);
            //    context.Resources.Add(user_03);
            //    context.Resources.Add(user_04);
            //    context.Resources.Add(user_05);
            //    context.Resources.Add(user_06);

            //    context.SaveChanges();
            //}

            context.SaveChanges();
        }
    }
}
