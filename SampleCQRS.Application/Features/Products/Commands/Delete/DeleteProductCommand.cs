using SampleCQRS.Application.CQRSInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCQRS.Application.Features.Products.Commands.Delete
{
    public class DeleteProductCommand : ICommand
    {
        public int id { get; set; }
    }
}
