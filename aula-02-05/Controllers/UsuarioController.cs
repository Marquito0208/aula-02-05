using aula_02_05.Data;
using aula_02_05.DTOs;
using aula_02_05.Models;
using Microsoft.AspNetCore.Mvc;

namespace aula_02_05.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly DataContext _dataContext;  

        public UsuarioController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult LoginPage()
        {
            return View();
        }

        public IActionResult EfetuarLogin(LoginDTO request)
        {
            var getUser =_dataContext.Usuarios.FirstOrDefault(x => x.UserEmail == request.Email);
            if (getUser == null)
            {
                //TODO: Retornar um card com a informacao que nao ha cadastro
                return NotFound();
            }
            if (BCrypt.Net.BCrypt.Verify(request.Senha, getUser.PasswordHash))
            {
                return NotFound();
            }
            return RedirectToAction("Home", "Index");
        }

        public IActionResult CadastroPage() 
        { 
        
        return View();
        }

        public IActionResult EfetuarCadastro(CadastroDTO request)
        {

            var findUser = _dataContext.Usuarios.FirstOrDefault(x => x.UserEmail == request.UserEmail);
            if (findUser != null)
            {
                return NotFound();
            }

            Usuario newUser = new Usuario
            {
                UserEmail = request.UserEmail,
                UserName = request.UserName,
                Nickname = request.Nickname,
                PasswordHash= BCrypt.Net.BCrypt.HashPassword(request.PasswordHash),
                DateRegister = DateTime.Now


            };

            _dataContext.Usuarios.Add(newUser);
            _dataContext.SaveChanges();


            return RedirectToAction("User", "LoginPage");
        }

        public IActionResult PerfilPage(int id)
        {
            var getUser = _dataContext.Usuarios.Find(id);

            ViewBag.user = getUser;

            return View();
        }

        public IActionResult EditarPerfil(int id, string newPassword,CadastroDTO request)
        {
            var getUser = _dataContext.Usuarios.Find(id);
        
            if (BCrypt.Net.BCrypt.Verify(request.PasswordHash, getUser.PasswordHash))
            {
              
                getUser.UserEmail = request.UserEmail;
                getUser.UserName = request.UserName;
                getUser.Nickname = request.Nickname;
                getUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
            }

            _dataContext.Update(getUser);
            _dataContext.SaveChanges();
    
            return RedirectToAction("PerfilPage");
        }

        public IActionResult DeletarPerfil(int id)
        {
            var getUser = _dataContext.Usuarios.Find(id);
            getUser.IsActive = false;

            _dataContext.Update(getUser);
            _dataContext.SaveChanges();
            return RedirectToAction("PerfilPage");
        }
    }
}
