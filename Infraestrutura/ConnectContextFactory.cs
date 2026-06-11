using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CPTMBack.Infraestrutura
{
    public class ConnectContextFactory : IDesignTimeDbContextFactory<ConnectContext>
    {
        public ConnectContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ConnectContext>();
            optionsBuilder.UseOracle("Data Source=localhost:1521/XEPDB1;User ID=CPTM;Password=root;");
            return new ConnectContext(optionsBuilder.Options);
        }
    }
}
