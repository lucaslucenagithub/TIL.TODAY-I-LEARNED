using RC.Recloti.Business.DataTransferObject;
using RC.Recloti.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RC.Recloti.Business.Interfaces
{
    public interface IAuthenticationService
    {
        //Task<Usuario> ValidarLoginAdmin(string email, string senha);
        Task<User> LoginValidator(LoginDto login, int idProfile);
        //Task<Usuario> ValidarLoginFacebook(LoginVM login, int idPerfil);
        //bool ValidarLoginSemCadastro(string token);
        //Task<(bool sucesso, string mensagem, Usuario data)> RecuperarSenha(string email, int idPerfil);
        //Task<(bool sucesso, string mensagem, Usuario data)> ValidarSenha(SenhaVM senhaVM);
        //Task<(bool sucesso, string mensagem, Usuario data)> EditarSenha(int usuarioId, string senha, bool redefinirSenha);
        Task<bool> EmailExiste(string email, int idProfile);
        //Task<bool> CpfExiste(string cpf, int idPerfil);
        //Task<bool> UsuarioExiste(int idUsuario);
    }
}
