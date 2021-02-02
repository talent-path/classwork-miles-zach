package com.tp.library.controller;

import com.tp.library.exceptions.*;
import com.tp.library.model.Book;
import com.tp.library.service.LibraryService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.NoSuchElementException;

@RestController
public class LibraryController {

    @Autowired
    LibraryService libraryService;

    @GetMapping("/books")
    public ResponseEntity getAllBooks() {
        ResponseEntity entity;
        try {
            entity = ResponseEntity.ok(libraryService.getAllBooks());
        } catch(EmptyCollectionException e) {
            entity = ResponseEntity.badRequest().body(e.getMessage());
        }
        return entity;
    }

    @GetMapping("/books/id/{id}")
    public ResponseEntity getBookById(@PathVariable Integer id) {
        ResponseEntity entity;
        try {
            entity = ResponseEntity.ok(libraryService.getBookById(id));
        } catch( InvalidBookIdException | BookNotFoundException e) {
            entity = ResponseEntity.badRequest().body(e.getMessage());
        }
        return entity;
    }

    @GetMapping("/books/title/{title}")
    public ResponseEntity getBooksByTitle(@PathVariable String title) {
        ResponseEntity entity;
        try {
            entity = ResponseEntity.ok(libraryService.getBooksByTitle(title));
        } catch(EmptyFieldException | EmptyCollectionException e) {
            entity = ResponseEntity.badRequest().body(e.getMessage());
        }
        return entity;
    }

    @GetMapping("/books/author/{author}")
    public ResponseEntity getBooksByAuthor(@PathVariable String author) {
        ResponseEntity entity;
        try {
            entity = ResponseEntity.ok(libraryService.getBooksByAuthor(author));
        } catch(EmptyFieldException | EmptyCollectionException e) {
            entity = ResponseEntity.badRequest().body(e.getMessage());
        }
        return entity;
    }

    @GetMapping("/books/year/{publicationYear}")
    public ResponseEntity getBooksByPublicationYear(@PathVariable Integer publicationYear) {
        ResponseEntity entity;
        try {
            entity = ResponseEntity.ok(libraryService.getBooksByPublicationYear(publicationYear));
        } catch(InvalidPublicationYearException | EmptyCollectionException e) {
            entity = ResponseEntity.badRequest().body(e.getMessage());
        }
       return entity;
    }

    @PostMapping("/books")
    public ResponseEntity addBook(@RequestBody Book book) {
        ResponseEntity entity;
        try {
            entity = ResponseEntity.ok(libraryService.saveBook(book));
        } catch(NullFieldException | EmptyFieldException | InvalidPublicationYearException | MissingAuthorException e) {
            entity = ResponseEntity.badRequest().body(e.getMessage());
        }
        return entity;
    }

    @PutMapping("/books/update/{id}")
    public ResponseEntity updateBook(@PathVariable Integer id, @RequestBody Book book) {
        ResponseEntity response;
        try {
            libraryService.updateBook(id, book);
            response = ResponseEntity.ok(book);
        } catch(BookNotFoundException | NullFieldException | InvalidPublicationYearException | MissingAuthorException | EmptyFieldException e) {
            response = ResponseEntity.badRequest().body(e.getMessage());
        }
        return response;
    }

    @DeleteMapping("/books/delete/{id}")
    public ResponseEntity deleteBook(@PathVariable Integer id) {
        ResponseEntity response;
        try {
            libraryService.deleteBook(id);
            response = ResponseEntity.accepted().build();
        } catch(BookNotFoundException e) {
            response = ResponseEntity.notFound().build();
        }
        return response;
    }
}
