Come prima cosa creare il database su mssql con la connessione "(localdb)\mssqllocaldb".
Dopo aver creato il database Creare il progetto su visual studio: web application (entityframework),
Se non compare andare nell'installer e assicurarsi di aver selezionato **.net modelli di sviluppo**.

scaricare pacchetti
entityframework e anche i tool

Dopo aver Creato il progetto Creare una cartella **Database** nel quale verranno inserite le classi del db e poi importare il db stesso:
![[Pasted image 20260128223450.png]]
![[Pasted image 20260128223508.png]]
![[Pasted image 20260128223532.png]]
![[Pasted image 20260128223656.png]]
![[Pasted image 20260128223719.png]]


Auth:
modificare il web config:
<authentication mode="Forms">
  <forms loginUrl="~/Login/Login" timeout="30"></forms>
 </authentication>
FormsAuthentication.SetAuthCookie(user.Username, false); -> creare il cookie di auth


Login
[HttpPost]
        public async Task<ActionResult> Login(UserLoginModel user) -> creato un dto per il login con solo username e password
        {
            if (ModelState.IsValid)
            {
                if (await UserService.CheckUserPassword(user))
                {
                    FormsAuthentication.SetAuthCookie(user.Username, false);

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("Password", "Credenziali non valide");
            }

            return View(user);
        }

public static async Task<bool> CheckUserPassword(UserLoginModel user)
        {
            using (var db = new RegistroEntities2())
            {
                return await db.User.AnyAsync(u => u.Username == user.Username && u.Password == user.Password);
            }
        }
@using System.Web.UI.HtmlControls
@model Registro.Models.UserLoginModel

<div class="d-flex  align-items-center justify-content-center">
    <div 
        class="d-flex flex-column align-items-center justify-content-center  w-50 h-75 rounded-3 text-white"
        style="background-color: #332d2d;">
        @using (Html.BeginForm("Index", "Home", FormMethod.Post))
        {
            <div class="form-outline form-white mb-4">
                @Html.LabelFor(user=>user.Username)
                @Html.TextBoxFor(user=>user.Username,new{@class ="form-control form-control-lg"})
                @Html.ValidationMessageFor(user=>user.Username,"",new{@class = "text-danger"} )
            </div>
            <div>
                @Html.LabelFor(user=>user.Password)
                @Html.TextBoxFor(user=>user.Password,new{@class ="form-control form-control-lg"})
                @Html.ValidationMessageFor(user=>user.Password,"",new{@class = "text-danger"} )
            </div>
           <div type="submit" class="d-flex flex-column align-items-center justify-content-center"> <button class="mt-3 btn btn-primary">Login</button></div>
        }
    </div>
</div>

per verificare che sia loggato nel cshtml

@if (User.Identity.IsAuthenticated)
{
   ...
}

mentre nel controller basta mettere [authorize]