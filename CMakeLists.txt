cmake_minimum_required(VERSION 3.5.1)
project(CodeCompassCSharp)

list( APPEND CMAKE_MODULE_PATH "${CMAKE_SOURCE_DIR}/cmake-submodules" )

find_package( CSharp REQUIRED )

include( ${CSHARP_USE_FILE} )

#csharp_add_library ( model )

csharp_add_executable ( parser "" "${CMAKE_SOURCE_DIR}/Program.cs"	)

#add_dependencies( parser model )
#;model/CsharpAstNode.cs;model/CsharpEntity.cs;model/CsharpMethod.cs;model/CsharpClass.cs;model/CsharpEnum.cs;model/CsharpNamespace.cs;model/CsharpDbContext.cs;model/CsharpEnumMember.cs;model/CsharpVariable.cs    ${CMAKE_SOURCE_DIR}/AstVisitor.cs