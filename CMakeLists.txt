cmake_minimum_required(VERSION 3.5.1)
project(CodeCompassCSharp)

list( APPEND CMAKE_MODULE_PATH "${CMAKE_SOURCE_DIR}/cmake-submodules" )

find_package( CSharp REQUIRED )

include( ${CSHARP_USE_FILE} )

csharp_add_library ( model ${CMAKE_SOURCE_DIR}/model/*.cs)

csharp_add_executable ( parser model ${CMAKE_SOURCE_DIR}/*.cs)

add_dependencies( parser model )