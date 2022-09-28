using MaisSaude.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;

namespace MaisSaude.Interfaces
{
    public interface ILoginRepository
    {
        string Logar(string email, string senha);

    }
}
