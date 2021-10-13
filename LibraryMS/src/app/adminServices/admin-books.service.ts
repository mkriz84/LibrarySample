import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IBook } from '../adminmodule/books/books';

@Injectable({
  providedIn: 'root'
})
export class AdminBooksService {

 // private urlBook: string = "http://localhost:5001/books"; http://localhost:49265/api/books
  private urlBook: string = "http://localhost:49265/api/books"; 

  constructor(private http: HttpClient) { }

  getBook(): Observable<IBook[]> {
    return this.http.get<IBook[]>(this.urlBook);
  }
  getBookbyStatus(fil: string): Observable<IBook[]> {
    return this.http.get<IBook[]>(this.urlBook + '?bstatus=' + fil);
  }

  getBooks(fil: string): Observable<IBook[]> {
    return this.http.get<IBook[]>(this.urlBook);
  }
  getMostCommonWords(id:number): Observable<IBook[]> {
    return this.http.get<IBook[]>(this.urlBook + '/'+ id );
  }
  SearchWithText(id:number,txt:string ): Observable<IBook[]> {
    return this.http.get<IBook[]>(this.urlBook  + '/'+ id +'/'+ txt);
  }


  getBookbyId(id: number): Observable<IBook> {
    return this.http.get<IBook>(this.urlBook + '/' + id);
  }




  putBook(book: IBook) {
    return this.http.post<IBook>(this.urlBook, book)
  }
  deleteBook(id: number): Observable<IBook> {
    return this.http.delete<IBook>(this.urlBook + '/' + id);
  }
  updateBook(book: IBook): Observable<IBook> {
    return this.http.put<IBook>(this.urlBook + '/' + book.id, book);
  }


  currentBook: IBook = {

    id: null,
    bookName: null,
    btitle: '',
    bcatag: '',
    bauthor: '',
    bcopies: null,
    bpub: '',
    pubname: '',
    bisbn: '',
    byear: null,
    bdate: null,
    bstatus: '',
  }

}
