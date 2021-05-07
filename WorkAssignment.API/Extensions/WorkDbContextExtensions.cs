using System.Collections.Generic;
using WorkAssignment.Migrations;

namespace WorkAssignment.API.Extensions
{
    public static class WorkDbContextExtensions
    {
        public static void MultiBulkMerge<T1, T2, T3, T4>(this WorkDbContext dbContext, IList<T1> list1, IList<T2> list2, IList<T3> list3, IList<T4> list4) 
            where T1: class where T2 : class where T3: class where T4 : class
        {
            dbContext.BulkMerge(list1, options =>
            {
                options.InsertKeepIdentity = true;
                options.MergeKeepIdentity = true;
                options.InsertIfNotExists = true;
            });
            dbContext.BulkMerge(list2, options =>
            {
                options.InsertKeepIdentity = true;
                options.MergeKeepIdentity = true;
                options.InsertIfNotExists = true;
            });
            dbContext.BulkMerge(list3, options =>
            {
                options.InsertKeepIdentity = true;
                options.MergeKeepIdentity = true;
                options.InsertIfNotExists = true;
            });
            dbContext.BulkMerge(list4, options =>
            {
                options.InsertKeepIdentity = true;
                options.MergeKeepIdentity = true;
                options.InsertIfNotExists = true;
            });
        }
    }
}