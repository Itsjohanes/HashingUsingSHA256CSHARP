// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography;
using System.Text;

static string EncryptPassword(string password)
{
    using (SHA256 sha256Hash = SHA256.Create())
    {
        // Convert the password string to a byte array
        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

        // Convert the byte array to a string
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < bytes.Length; i++)
        {
            builder.Append(bytes[i].ToString("x2"));
        }
        return builder.ToString();
    }
}

static bool VerifyPassword(string enteredPassword, string storedPassword)
{
    // Hash the entered password using SHA256
    string hashedPassword = EncryptPassword(enteredPassword);

    // Compare the hashed password with the stored password
    return hashedPassword.Equals(storedPassword);
}


    // Create a password
    string password = "password1";
    string hashedPassword = EncryptPassword(password);
    // Verify the password
    bool isPasswordCorrect = VerifyPassword("password", hashedPassword);
    Console.WriteLine("Is the password correct? " + isPasswordCorrect);
