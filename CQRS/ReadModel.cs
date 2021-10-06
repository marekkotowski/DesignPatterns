using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WzorceProjektowe_1.CQRS
{

    public interface ICommand
    {
        Guid Id { get; }
    }

    public interface ProductDao
    {
        RateProduct GetRateProduct();
        ICollection<RateProduct> FindByName(string name);
    }

    public class RateProduct : ICommand
    {
        public Guid Id { get; set; }
        public int ProductId { get; set; }

        public RateProduct()
        {
            this.Id = Guid.NewGuid();
        }
    }

}
