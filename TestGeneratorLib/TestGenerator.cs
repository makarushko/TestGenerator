using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using TestGeneratorLib.Info;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace TestGeneratorLib
{
    public class TestGenerator: ITestGenerator
    {
        private static readonly SyntaxToken PublicModifier;
        private static readonly TypeSyntax VoidReturnType;
        private static readonly AttributeSyntax SetupAttribute;
        private static readonly AttributeSyntax MethodAttribute;
        private static readonly AttributeSyntax ClassAttribute;

        static TestGenerator()
        {
            PublicModifier = SyntaxFactory.Token(SyntaxKind.PublicKeyword);
            VoidReturnType = SyntaxFactory.ParseTypeName("void");
            SetupAttribute = SyntaxFactory.Attribute(SyntaxFactory.ParseName("SetUp"));
            MethodAttribute = SyntaxFactory.Attribute(SyntaxFactory.ParseName("Test"));
            ClassAttribute = SyntaxFactory.Attribute(SyntaxFactory.ParseName("TestFixture"));
        }

        public Dictionary<string, string> GenerateTests(FileInfo fileInfo)
        {
            var fileNameCode = new Dictionary<string, string>();

            foreach (var classInfo in fileInfo.Classes)
            {
                var classDeclaration = GenerateClass(classInfo);
                var compilationUnit = SyntaxFactory.CompilationUnit()
                    .AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System")))
                    .AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("NUnit.Framework")))
                    .AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("MainPart.Files")))
                    .AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("Moq")))
                    .AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System.Collections.Generic")))
                    .AddMembers(classDeclaration);
                fileNameCode.Add(classInfo.ClassName + "Test", compilationUnit.NormalizeWhitespace().ToFullString());
            }

            return fileNameCode;
        }
    }
}