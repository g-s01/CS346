# CS346 - Software Engineering Laboratory

## Assignment-2

Develop a Visual Basic application that manages the services and inventory of the IITG central library.
The application must keep records of the books present in the library, books borrowed, borrower details, and so on.
It must also offer facilities to students and faculty to issue, return, and renew books. 
Use MS- Access or MySQL for your database requirements.

## UNDER-CONSTRUCTION
- [X] Design
  - [X] Admin side (@`Ajay`)
  - [X] Student and Faculty side (@`Sarvesh`)
  - [X] Landing page (@`Gaurav`)
  - [X] Registration page (@`Gaurav`)
  - [X] Login page (@`Gaurav`)
  - [X] Search page (@`Faizan Amir`)
  - [X] Database Design (@`g-s01` and @`Gautam Juneja`) 
- [X] Frontend
  - [X] Admin side (@`Ajay`)
  - [X] Student and Faculty side (@`Sarvesh`)
  - [X] Landing page (@`Gaurav`)
  - [X] Registration page (@`Gaurav`)
  - [X] Login page (@`Gaurav`)
  - [X] Search page (@`Faizan Amir`)
  - [X] Routing (@`Sarvesh`)
  - [X] Stack usage (@`Ajay`)
  - [X] Increase balance button 
- [ ] Backend
  - [X] Login Page
    - [X] Checking whether the entry exists in the database or not (@`Gautam Juneja`) 
  - [X] Registration Page
    - [X] Taking input from the user and storing it in the database (@`Gautam Juneja`) 
    - [X] Password Strength Checker (@`Gautam Juneja`)
    - [X] Regex for only emails ending with `@iitg.ac.in` (@`Gautam Juneja`) 
    - [X] Checking whether an account is already made or not (@`Gautam Juneja`) 
    - [X] OTP (@`Gautam Juneja`) 
  - [X] Admin Login (@`Sarvesh`)
    - [X] Check the admin password and then only open the admin dashboard
  - [ ] Admin
    - [ ] Admin Dashboard (@`Ajay`)
    - [ ] Admin Search (@`Faizan Amir`)
    - [X] Manual Transactions (@`Sarvesh`)
    - [ ] Book Management (@`Ajay`)
  - [ ] Student & Faculty Page
    - [X] Showing borrowed book list (@`g-s01`)
    - [X] Showing overdue book list (@`g-s01`)
    - [X] Showing all unborrowed book list (@`g-s01`)
    - [X] Showing fine from all overdue books (@`g-s01`)
    - [ ] Payment of fine (@`Gaurav`)
        - [X] Taking a fine amount as input
        - [X] Maintaining the balance of user
        - [X] Checking that the user has enough balance to pay input amount
        - [ ] Send email to user a random code for 2fa
        - [ ] Send confirmation for email
    - [X] Searching of books (@`g-s01` and @`Faizan Amir`)
    - [X] Renew of books (@`g-s01`)
    - [X] Return of books (@`g-s01`)
    - [X] Issue of books (@`g-s01`)
    - [ ] Increase balance (@`g-s01`)
      - [ ] Send email for 2fa
    - [X] Writing all the transactions to the admin (@`g-s01`)
- [ ] Documentation
  - [ ] ER Diagram (@`Faizan Amir`)
  - [X] DFD (@`Faizan Amir` and @`Gautam Juneja`)
  - [X] Userflow diagram (@`Faizan Amir` and @`Gautam Juneja`)
## Running the project

### Setting up the database

1. Download `XAMPP` from [here](https://www.apachefriends.org/)
2. Install `XAMPP`
3. Start the `Apache` and `MySQL` server
 
   <img width="670" alt="image" src="https://github.com/g-s01/CS346/assets/95131287/a976a5f0-814e-411d-ad93-6990996d0c59">
   
4. Make a database named `LMS` from the admin panel of the MySQL server
   
   <img width="843" alt="image" src="https://github.com/g-s01/CS346/assets/95131287/d43992d9-3e1f-4c6b-9b0d-3e4be5fd7100">
   
5. Make five tables in `LMS`:
   
   * **admin**

     This table stores the information related to the admin.
     
     | Column Name   | Data-Type   | Work                                                  |
     |---------------|-------------|-------------------------------------------------------|
     | username      | VARCHAR(50) | Stores the username for admin login                   |
     | Password      | VARCHAR(50) | Stores the password for admin login                   |
     | fineCollected | INT(11)     | Stores the total fine collected by the admin          |

   * **books**

     This table stores the information related to all the books in the library.

     | Column Name | Data-Type   | Work                                                                  |
     |-------------|-------------|-----------------------------------------------------------------------|
     | ID          | INT(11)     | Stores the book ID                                                    |
     | isIssued    | BOOLEAN     | Stores the whether the book has been issued or not                    |
     | dueDate     | DATETIME    | Stores the due-date of the current issue if the books has been issued |
     | issuedTo    | VARCHAR(50) | Stores the user ID of the person to whom the book has been issued     |
     | isReserved  | BOOLEAN     | Stores whether the book is reserved only for faculties or not         |
     | authorName  | VARCHAR(50) | Stores the name of the author of the book                             |
     | Title       | VARCHAR(50) | Stores the name of the book                                           |
     | Subject     | VARCHAR(50) | Stores the subject in which the contents of the book come in          |

   * **borrowed_books**
  
     This table stores the information related to all the books which are currently issued.

     | Column Name | Data-Type   | Work                                                         |
     |-------------|-------------|--------------------------------------------------------------|
     | BookID      | INT(11)     | Stores the book ID                                           |
     | issuedToID  | VARCHAR(50) | Stores the username of the person to whom the book is issued |
     | issueDate   | DATETIME    | Stores the date when the book was issued                     |
     | dueDate     | DATETIME    | Stores the due date of return                                |

   * **faculty**
  
     This table stores the information related to all the faculties registered on the system.

     | Column Name | Data-Type   | Work                                           |
     |-------------|-------------|------------------------------------------------|
     | ID          | VARCHAR(50) | Stores the username of the faculty             |
     | Password    | VARCHAR(50) | Stores the password of the faculty             |
     | Name        | VARCHAR(50) | Stores the name of the faculty                 |
     | Fine        | INT(11)     | Stores the current fine in the name of faculty |
     | Balance     | INT(11)     | Stores the current balance in the faculty's wallet |

   * **students**
  
     This table stores the information related to all the students registered on the system.

     | Column Name | Data-Type   | Work                                               |
     |-------------|-------------|----------------------------------------------------|
     | ID          | VARCHAR(50) | Stores the username of the student                 |
     | Password    | VARCHAR(50) | Stores the password of the student                 |
     | Name        | VARCHAR(50) | Stores the name of the student                     |
     | Fine        | INT(11)     | Stores the current fine in the name of student     |
     | Balance     | INT(11)     | Stores the current balance in the student's wallet |

   * **transactions**

     This table stores all the transactions that are performed in the database, like issue of books, return of books, renew of books, payment of fine, increasing balance etc.

     | Column Name   | Data-Type    | Work                                                  |
     |---------------|--------------|-------------------------------------------------------|
     | transaction   | VARCHAR(1000)| Stores all the transactions that happen on the system |	

8. Download MySQL version `6.9.9` from [here](https://downloads.mysql.com/archives/c-net/?fbclid=IwAR0sQZdA3D-Xo_-Y85CcT7JtOEc7vT3ygnH04clvTmOZoLKmITruUJ03iFQ)
6. Open the project in `Visual Studio 2010/13`
7. In the properties of the project, add `MySQL.data` in the `References`
   
   <img width="637" alt="image" src="https://github.com/g-s01/CS346/assets/95131287/c99085a0-d3cf-4d2e-8b21-72278c208f98">
   
8. The database is now setup for use!

### Building the project

1. Open the project in `Visual Studio 2010/13`
2. Click on `Start`
   
   <img width="1038" alt="image" src="https://github.com/g-s01/CS346/assets/95131287/96501739-721d-42c9-80b4-c85bc4ec76a2">
   
3. The application starts!
   
   <img width="903" alt="image" src="https://github.com/g-s01/CS346/assets/95131287/176bee4e-d5b2-4413-8a20-0914bee1b90e">

# Credits
* Durgesam Ajay
* Faizan Amir
* Gaurav
* [Gautam Juneja](https://github.com/HarmlessCoder)
* [Gautam Sharma](https://g-s01.github.io/)
* [Gholap Sarvesh Sarjerao](https://github.com/sarg19)
