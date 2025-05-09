using System.Data;
using AutoMapper;
using PetShop.Manager.Application.Contracts.Interfaces.Persistence.Commands.Store;
using PetShop.Manager.Application.Contracts.Models.InputModels.Store;
using PetShop.Manager.Persistence.DataModels;
using PetShop.Manager.Persistence.DataModels.Extensions;
using PetShop.Manager.Persistence.DataModels.Store;

namespace PetShop.Manager.Persistence.Command.Store
{
    public class CustomerCommandRepository : ICustomerCommandRepository
    {
        private readonly IMapper _mapper;
        private readonly IDbConnection _dbConnection;


        public CustomerCommandRepository(IMapper mapper, IDbConnection dbConnection)
        {
            _mapper = mapper;
            _dbConnection = dbConnection;
            _dbConnection.Open();
        }

        public void AddPet(string cpf, int petId)
        {
            var customer = MemoryStorage
                .Customers
                .Values
                .FirstOrDefault(x => x.Cpf == cpf) ?? throw new ApplicationException();

            if (customer.Pets.Any(x => x.Id == petId))
            {
                return;
            }

            var pet = MemoryStorage
                .Pets
                .Values
                .FirstOrDefault(x => x.Id == petId);

            if (pet is null)
            {
                return;
            }

            customer.Pets.Add(pet);
        }

        public void ChangeEmail(string cpf, string email)
        {
            var customer = MemoryStorage
                .Customers
                .Values
                .FirstOrDefault(x => x.Cpf == cpf);

            if (customer is null)
            {
                return;
            }

            customer.Email = email;

        }

        public void RemovePet(string cpf, int petId)
        {
            var customer = MemoryStorage
                .Customers
                .Values
                .FirstOrDefault(x => x.Cpf == cpf) ?? throw new ApplicationException();

            
            if (!customer.Pets.Any(x => x.Id == petId))
            {
                return;
            }

            customer.Pets.Remove(customer.Pets.First(x => x.Id == petId));

        }
        public void Save(CustomerInputModel inputModel)
        {
            var customerDataModel = _mapper.Map<CustomerDataModel>(inputModel);

            if (inputModel.Id.HasValue)
            {
                MemoryStorage.Customers[inputModel.Id.Value] = customerDataModel;
                return;
            }

            InsertToDatabase(customerDataModel);
        }

        public void UpdateCustomer(int id, CustomerInputModel inputModel)
        {

            var customerDataModel = _mapper.Map<CustomerDataModel>(inputModel);

            UpdateToDatabase(customerDataModel);

        }

        private void InsertToDatabase(CustomerDataModel customerDataModel)
        {
            var command = _dbConnection.CreateCommand();
            command.CommandText = @"INSERT INTO Customers (name, birthday, cpf, email, created_at, created_by) 
                                    VALUES (:Name, :Birthday, :Cpf, :Email, :CreatedAt, :CreatedBy)";
            command.Parameters.Add(command.GetParameter(":Name", customerDataModel.Name));
            command.Parameters.Add(command.GetParameter(":Birthday", customerDataModel.Birthday, DbType.DateTime));
            command.Parameters.Add(command.GetParameter(":Cpf", customerDataModel.Cpf));
            command.Parameters.Add(command.GetParameter(":Email", customerDataModel.Email, DbType.String));
            command.Parameters.Add(command.GetParameter(":CreatedAt", DateTime.Now, DbType.DateTime));
            command.Parameters.Add(command.GetParameter(":CreatedBy", "System", DbType.String));
            command.ExecuteNonQuery();
        }

        private void UpdateToDatabase(CustomerDataModel customerDataModel)
        {
            var command = _dbConnection.CreateCommand();
            command.CommandText = @"UPDATE Customers 
                                    SET name = :Name, 
                                        birthday = :Birthday, 
                                        cpf = :Cpf, 
                                        email = :Email, 
                                        updated_at = :UpdatedAt, 
                                        updated_by = :UpdatedBy 
                                    WHERE id = :Id";
            command.Parameters.Add(command.GetParameter(":Name", customerDataModel.Name));
            command.Parameters.Add(command.GetParameter(":Birthday", customerDataModel.Birthday, DbType.DateTime));
            command.Parameters.Add(command.GetParameter(":Cpf", customerDataModel.Cpf));
            command.Parameters.Add(command.GetParameter(":Email", customerDataModel.Email, DbType.String));
            command.Parameters.Add(command.GetParameter(":UpdatedAt", DateTime.Now, DbType.DateTime));
            command.Parameters.Add(command.GetParameter(":UpdatedBy", "System", DbType.String));
            command.Parameters.Add(command.GetParameter(":Id", customerDataModel.Id, DbType.Int32));
            command.ExecuteNonQuery();
        }
        public bool DoesCustomerExist(int id)
        {
            var command = _dbConnection.CreateCommand();
            command.CommandText = "SELECT COUNT(1) FROM Customers WHERE id = :Id";
            command.Parameters.Add(command.GetParameter(":Id", id, DbType.Int32));

            var result = command.ExecuteScalar();
            return Convert.ToInt32(result) > 0;
        }
    }
}
