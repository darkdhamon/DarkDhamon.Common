# DarkDhamon.Common
In 2021, I decided to start creating a library of code of shortcuts and code structures that I commonly use in my applications.

## Features

### DarkDhamon.Common
#### Api Response Models
_Class ApiResponse_

This model can be used to return a message.

_Class ApiResponse&lt;T&gt;_

This model can return an object defined by the Generic Type Parameter in addition to a Message

_Class PagedApiResponse&lt;T&gt;_

This model can return a list of paginated objects as well as information regarding the page details.
#### Extension Methods
##### Enum
##### String


### DarkDhamon.Common.EntityFramework

### DarkDhamon.OS.Integration

## Changes

### DarkDhamon.Common V2022.10.15.1
 - Added a few string extensions

### V2022.10.14.21-Release
All future release will be on a project basis instead of a solution basis.

- All
    - Update to .NET 6
    - Fix All Nullable Warnings
- Common
    - Remove EF code from this project/Package
    - PagedApiResponse.Data no longer nullable
- Common.EntityFramework
    - Move EF code into the project/Package

### V2022.10.14.18-release
 - All
    - Update Versioning Name Scheme
    - Publishing any missing code

### V0.1.1
- Common
    - Pulls in OS.Integration
- OS.Integration
    - Windows
        - Verify OS for Window Specific functions
        - Disable Windows Screen Saver
### V0.1.0
- Common
    - standardized API response models
    - Basic Generic Entity based Repositories
    - Extensions
        - Enum.ToStringVariant that uses description Attribute
        - Useful null or whitespace shortcuts for strings
