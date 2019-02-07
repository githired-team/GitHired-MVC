
﻿using GitHired_MVC.Data;
using GitHired_MVC.Models;
using GitHired_MVC.Models.Interfaces;
using GitHired_MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHired_MVC.Controllers
{
    public class FocusController : Controller
    {
        private readonly IBoardManager _board;
        private readonly IColumnManager _column;
        private readonly IFocusManager _focus;
        private readonly IUserManager _user;
        private GitHiredDBContext _context { get; set; }

        public FocusController(IUserManager user,IBoardManager board, IColumnManager column, IFocusManager focus, GitHiredDBContext context)
        {
            _board = board;
            _column = column;
            _focus = focus;
            _user = user;
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            int userId = Convert.ToInt32(Request.Cookies["GitHiredCookie"]);
            return View(await _focus.GetFocus(userId));
            
        }

        //this is because the system didn't like two indexes even though they had diff params
        public async Task<IActionResult> ExisitingUserIndex(int id)
        {
            //var returnInfo = _context.Focus.Include(fu => fu.UserID);
            var focuses = await _focus.GetFocus(id);
            var focObj = from o in focuses
                         .Where(i => i.UserID == id)
                         select o;
            return RedirectToAction("Index", focObj.FirstOrDefault());
            //return View();
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            // Possible View Model
            // ViewData["UserID"] = new SelectList(_context.User, "ID", "Name");
            FocusViewModel fvm = new FocusViewModel();
            fvm.UserID = id;
            return View(fvm);
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("UserID, Name, DesiredPosition, Location, Skill, ResumeLink, CoverLetter")] Focus focus)
        {
            if (ModelState.IsValid)
            {
                await _focus.CreateFocus(focus);
                Board newBoard = new Board();
                newBoard.Name = focus.Name;
                newBoard.FocusID = focus.ID;
                await _board.CreateBoard(newBoard);
                Column newDefaultColInterested = new Column();
                newDefaultColInterested.BoardID = newBoard.ID;
                newDefaultColInterested.Name = "Interested";
                newDefaultColInterested.Order = 1;

                Column newDefaultColWIP = new Column();
                newDefaultColWIP.BoardID = newBoard.ID;
                newDefaultColWIP.Name = "Application";
                newDefaultColWIP.Order = 2;

                Column newDefaultColComplete = new Column();
                newDefaultColComplete.BoardID = newBoard.ID;
                newDefaultColComplete.Name = "Submitted";
                newDefaultColComplete.Order = 3;

                Column newDefaultColInterview = new Column();
                newDefaultColInterview.BoardID = newBoard.ID;
                newDefaultColInterview.Name = "Interview";
                newDefaultColInterview.Order = 4;

                await _column.CreateColumn(newDefaultColInterested);
                await _column.CreateColumn(newDefaultColWIP);
                await _column.CreateColumn(newDefaultColComplete);
                await _column.CreateColumn(newDefaultColInterview);
                return RedirectToAction(nameof(Index), focus);
            }
            return RedirectToAction(nameof(Index), focus);

        }

        //edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var focus = await _focus.GetSingleFocus(id);

            FocusViewModel fvm = new FocusViewModel();
            fvm.Focus = focus;
            fvm.UserID = id;
            if (focus == null)
            {
                return NotFound();
            }
            return View(fvm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("ID, UserID, Name, DesiredPosition, Location, Skill,ResumeLink, CoverLetter")] Focus focus)
        {
            await _focus.UpdateFocus(focus);
            return RedirectToAction(nameof(Index));
        }

        

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var focus = await _focus.DeleteFocus(id);
            return RedirectToAction(nameof(Index));
        }<DirectedGraph xmlns="http://schemas.microsoft.com/vs/2009/dgml">
  <Nodes>
    <Node Id="(@1 Namespace=GitHired_MVC Type=Startup Member=(Name=Configure OverloadingParameters=[(@2 Namespace=Microsoft.AspNetCore.Builder Type=IApplicationBuilder),(@3 Namespace=Microsoft.AspNetCore.Hosting Type=IHostingEnvironment)]))" Category="CodeSchema_Method" CodeSchemaProperty_IsPublic="True" CommonLabel="Configure" Icon="Microsoft.VisualStudio.Method.Public" IsDragSource="True" Label="Configure(IApplicationBuilder, IHostingEnvironment) : void" SourceLocation="(Assembly=file:///C:/Users/agent/codefellows/401/GitHired-MVC/GitHired-MVC/GitHired-MVC/Startup.cs StartLineNumber=38 StartCharacterOffset=20 EndLineNumber=38 EndCharacterOffset=29)" />
    <Node Id="(@1 Namespace=GitHired_MVC Type=Startup)" Visibility="Hidden" />
  </Nodes>
  <Links>
    <Link Source="(@1 Namespace=GitHired_MVC Type=Startup)" Target="(@1 Namespace=GitHired_MVC Type=Startup Member=(Name=Configure OverloadingParameters=[(@2 Namespace=Microsoft.AspNetCore.Builder Type=IApplicationBuilder),(@3 Namespace=Microsoft.AspNetCore.Hosting Type=IHostingEnvironment)]))" Category="Contains" />
  </Links>
  <Categories>
    <Category Id="CodeSchema_Member" Label="Member" Icon="CodeSchema_Field" />
    <Category Id="CodeSchema_Method" Label="Method" BasedOn="CodeSchema_Member" Icon="CodeSchema_Method" />
    <Category Id="Contains" Label="Contains" Description="Whether the source of the link contains the target object" IsContainment="True" />
  </Categories>
  <Properties>
    <Property Id="CodeSchemaProperty_IsPublic" Label="Is Public" Description="Flag to indicate the scope is Public" DataType="System.Boolean" />
    <Property Id="CommonLabel" DataType="System.String" />
    <Property Id="Icon" Label="Icon" DataType="System.String" />
    <Property Id="IsContainment" DataType="System.Boolean" />
    <Property Id="IsDragSource" Label="IsDragSource" Description="IsDragSource" DataType="System.Boolean" />
    <Property Id="Label" Label="Label" Description="Displayable label of an Annotatable object" DataType="System.String" />
    <Property Id="SourceLocation" Label="Start Line Number" DataType="Microsoft.VisualStudio.GraphModel.CodeSchema.SourceLocation" />
    <Property Id="Visibility" Label="Visibility" Description="Defines whether a node in the graph is visible or not" DataType="System.Windows.Visibility" />
  </Properties>
  <QualifiedNames>
    <Name Id="Assembly" Label="Assembly" ValueType="Uri" />
    <Name Id="Member" Label="Member" ValueType="System.Object" />
    <Name Id="Name" Label="Name" ValueType="System.String" />
    <Name Id="Namespace" Label="Namespace" ValueType="System.String" />
    <Name Id="OverloadingParameters" Label="Parameter" ValueType="Microsoft.VisualStudio.GraphModel.GraphNodeIdCollection" Formatter="NameValueNoEscape" />
    <Name Id="Type" Label="Type" ValueType="System.Object" />
  </QualifiedNames>
  <IdentifierAliases>
    <Alias n="1" Uri="Assembly=$(51df8742-b446-486f-b70e-d10abc8ae9c3.OutputPathUri)" />
    <Alias n="2" Uri="Assembly=file:///C:/Program Files/dotnet/sdk/NuGetFallbackFolder/microsoft.aspnetcore.http.abstractions/2.2.0/lib/netstandard2.0/Microsoft.AspNetCore.Http.Abstractions.dll" />
    <Alias n="3" Uri="Assembly=file:///C:/Program Files/dotnet/sdk/NuGetFallbackFolder/microsoft.aspnetcore.hosting.abstractions/2.2.0/lib/netstandard2.0/Microsoft.AspNetCore.Hosting.Abstractions.dll" />
  </IdentifierAliases>
  <Paths>
    <Path Id="51df8742-b446-486f-b70e-d10abc8ae9c3.OutputPathUri" Value="file:///C:/Users/agent/codefellows/401/GitHired-MVC/GitHired-MVC/GitHired-MVC/bin/Debug/netcoreapp2.2/GitHired-MVC.dll" />
  </Paths>
</DirectedGraph>

        //detail may come later
    }
}