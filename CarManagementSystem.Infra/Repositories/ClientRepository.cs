using System.Data;
using CarManagementSystem.Domain.Model;
using CarManagementSystem.Infra.DbContext;
using CarManagementSystem.Services.Repositories;
using Microsoft.Data.SqlClient;

namespace CarManagementSystem.Infra.Repositories
{
    public class ClientRepository(ApplicationDbContext context, IDbConnectivity dbConnectivity)
        : BaseRepository<Client>(context), IClientRepository
    {
        private readonly IDbConnectivity _dbConnectivity = dbConnectivity ?? throw new ArgumentNullException(nameof(dbConnectivity));

        //not tested
        public async Task<IEnumerable<Client>> GetClientsWithCars()
        {
            var clients = new List<Client>();
            try
            {
                await using var command =
                    _dbConnectivity.DbCommand("SELECT * FROM Clients c JOIN Cars ca ON c.ClientId = ca.ClientId");
                await using var reader = await command.ExecuteReaderAsync();
                while (reader.Read())
                {
                    var client = MapClientFromReader(reader);
                    var car = MapCarFromReader(reader);

                    client.Cars.Add(car);

                    clients.Add(client);
                }
            }
            catch (Exception ex)
            {
                //add logger
            }

            return clients;
        }

        private Client MapClientFromReader(IDataRecord reader)
        {
            return new Client
            {
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                Email = reader["Email"].ToString(),
                PhoneNumber = reader["PhoneNumber"].ToString(),
                Id = Convert.ToInt32(reader["ClientId"])
            };
        }

        private Car MapCarFromReader(IDataRecord reader)
        {
            return new Car
            {
                Brand = reader["Brand"].ToString(),
                Model = reader["Model"].ToString(),
                RegistrationNumber = reader["RegistrationNumber"].ToString(),
                ProductionDate = Convert.ToDateTime(reader["ProductionDate"]),
                Id = Convert.ToInt32(reader["CarId"]),
            };
        }
    }
}