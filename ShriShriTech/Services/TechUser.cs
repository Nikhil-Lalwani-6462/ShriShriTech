using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ShriShriTech.Data;
using System.Security.Cryptography;

namespace ShriShriTech.Services
{
    public interface ITechUser
    {
        public Task<bool> AddUser(user user);
        public Task<bool> VerifyIdentityByEmail(string email);
    }
    public class TechUser : ITechUser
    {
        private readonly ShriShriTechContext _context;
        private readonly string _connectionString;
        public TechUser(ShriShriTechContext context, IConfiguration configuration) 
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<bool> AddUser(user user) 
        {
           if(user == null) 
                return false;

            var client = await (from obj in _context.ClientAdmins
                           where obj.StoreName == user.StoreName
                           select obj).FirstOrDefaultAsync();
            var saltKey = passSalt();
            var hash = passHash(user.Pass,saltKey);

            if (client.Id == null)
                return false;
                using (SqlConnection con = new SqlConnection(_connectionString)) 
                {
                    using (SqlCommand cmd = new SqlCommand("Add_TechUser", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("Client_Id", client.Id);
                        cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", user.LastName);
                        cmd.Parameters.AddWithValue("@Email", user.Email);
                        cmd.Parameters.AddWithValue("@ContactNo", user.ContactNo);
                        cmd.Parameters.AddWithValue("@PasswordHash",hash);
                        cmd.Parameters.AddWithValue("@PasswordSalt", saltKey);
                        cmd.Parameters.AddWithValue("@Designation", user.Designation);
                        cmd.Parameters.AddWithValue("@IsActive", true);
                        cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Today);
                        cmd.Parameters.AddWithValue("@City", user.City);
                        cmd.Parameters.AddWithValue("@District", user.District);
                        cmd.Parameters.AddWithValue("@PinCode", user.Pincode);
                        cmd.Parameters.AddWithValue("@Store_Address", user.Store_Address);
                        cmd.Parameters.AddWithValue("@State", user.State);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        return true;


                    }

                }


        }
        public string passSalt() 
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create()) 
            {
                rng.GetBytes(salt);
            }
            var saltKey = Convert.ToBase64String(salt);
            return saltKey;
        }
        public string passHash(string password, string salt) 
        {
            byte[] saltbytes = Convert.FromBase64String(salt);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2
                (
                    password,
                    saltbytes,
                    100000,
                    HashAlgorithmName.SHA256,
                    32
                );
            return Convert.ToBase64String ( hash ); 
        }
        public async Task<bool> VerifyIdentityByEmail(string email) 
        {
            if (String.IsNullOrEmpty(email))
                return false;

            string subject = "Check Identity";
            int rndnmber = RandomNumber();


            return true;
        }
        public int RandomNumber() 
        {
           return Random.Shared.Next(10,100);
        }



    }
}
