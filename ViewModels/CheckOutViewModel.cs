using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc;
using System.Collections.Generic;

namespace Bookish.ViewModels;

public class CheckOutViewModel{

    public int CheckOutId {get; set;}
    public int MemberId{get;set;}
    public int CopyId{get;set;}

    public SelectList Members{get;set;}
    public SelectList BookCopies{get;set;}
}