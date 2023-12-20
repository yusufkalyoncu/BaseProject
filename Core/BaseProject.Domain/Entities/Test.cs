using System;
using BaseProject.Domain.Entities.Common;

namespace BaseProject.Domain.Entities
{
    public class Test : BaseEntity
    {
        public string Name { get; set; }

        public Test(string name)
        {
            Name = name;
        }
    }
}

