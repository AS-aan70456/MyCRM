#pragma checksum "C:\Users\User\Desktop\Prodject complite\MyCRM\MyCRM\Views\Record\Record.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6890620b9e7d03895891138912625e92b665e1a4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Record_Record), @"mvc.1.0.view", @"/Views/Record/Record.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6890620b9e7d03895891138912625e92b665e1a4", @"/Views/Record/Record.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57218c316b6921e2cd61027a2387edc31a2d9471", @"/Views/_ViewImports.cshtml")]
    public class Views_Record_Record : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div>
    <div class=""app-main-layout"">
        <nav class=""navbar orange lighten-1"">
            <div class=""nav-wrapper"">
                <div class=""navbar-left"">
                    <a href=""#"">
                        <i class=""material-icons black-text"">dehaze</i>
                    </a>
                    <span class=""black-text"">12.12.12</span>
                </div>

                <ul class=""right hide-on-small-and-down"">
                    <li>
                        <a class=""dropdown-trigger black-text""
                           href=""#""
                           data-target=""dropdown"">
                            USER NAME
                            <i class=""material-icons right"">arrow_drop_down</i>
                        </a>

                        <ul id='dropdown' class='dropdown-content'>
                            <li>
                                <a href=""#"" class=""black-text"">
                                    <i class=""material-icons"">account_circ");
            WriteLiteral(@"le</i>Профиль
                                </a>
                            </li>
                            <li class=""divider"" tabindex=""-1""></li>
                            <li>
                                <a href=""#"" class=""black-text"">
                                    <i class=""material-icons"">assignment_return</i>Выйти
                                </a>
                            </li>
                        </ul>
                    </li>
                </ul>
            </div>
        </nav>

        <ul class=""sidenav app-sidenav open"">
            <li>
                <a href=""#"" class=""waves-effect waves-orange pointer"">Счет</a>
            </li>
            <li>
                <a href=""#"" class=""waves-effect waves-orange pointer"">История</a>
            </li>
            <li>
                <a href=""#"" class=""waves-effect waves-orange pointer"">Планирование</a>
            </li>
            <li>
                <a href=""#"" class=""waves-effect waves-orang");
            WriteLiteral(@"e pointer"">Новая запись</a>
            </li>
            <li>
                <a href=""#"" class=""waves-effect waves-orange pointer"">Категории</a>
            </li>
        </ul>

        <main class=""app-content"">
            <div class=""app-page"">

                <div>
                    <div class=""page-title"">
                        <h3>Новая запись</h3>
                    </div>

                    <form class=""form"">
                        <div class=""input-field"">
                            <select>
                                <option>
                                    name cat
                                </option>
                            </select>
                            <label>Выберите категорию</label>
                        </div>

                        <p>
                            <label>
                                <input class=""with-gap""
                                       name=""type""
                                       type=""");
            WriteLiteral(@"radio""
                                       value=""income"" />
                                <span>Доход</span>
                            </label>
                        </p>

                        <p>
                            <label>
                                <input class=""with-gap""
                                       name=""type""
                                       type=""radio""
                                       value=""outcome"" />
                                <span>Расход</span>
                            </label>
                        </p>

                        <div class=""input-field"">
                            <input id=""amount""
                                   type=""number"">
                            <label for=""amount"">Сумма</label>
                            <span class=""helper-text invalid"">amount пароль</span>
                        </div>

                        <div class=""input-field"">
                            <input id=""descr");
            WriteLiteral(@"iption""
                                   type=""text"">
                            <label for=""description"">Описание</label>
                            <span class=""helper-text invalid"">description пароль</span>
                        </div>

                        <button class=""btn waves-effect waves-light"" type=""submit"">
                            Создать
                            <i class=""material-icons right"">send</i>
                        </button>
                    </form>
                </div>

            </div>
        </main>

        <div class=""fixed-action-btn"">
            <a class=""btn-floating btn-large blue"" href=""#"">
                <i class=""large material-icons"">add</i>
            </a>
        </div>
    </div>
</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
