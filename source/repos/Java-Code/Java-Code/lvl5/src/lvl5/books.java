package lvl5;

public class books {
	private String title;
	private String author;
	private String publisher;
	private String copyRightDate;
	public books(String title, String author, String publisher,String copyRightDate){
		this.title=title;
		this.author=author;
		this.publisher=publisher;
		this.copyRightDate=copyRightDate;
		
	}
	public String getTitle() {
		return title;
	}
	public void setTitle(String title) {
		this.title = title;
	}
	public String getAuthor() {
		return author;
	}
	public void setAuthor(String author) {
		this.author = author;
	}
	public String getPublisher() {
		return publisher;
	}
	public void setPublisher(String publisher) {
		this.publisher = publisher;
	}
	public String getCopyRightDate() {
		return copyRightDate;
	}
	public void setCopyRightDate(String copyRightDate) {
		this.copyRightDate = copyRightDate;
	}
	public String toString() {
		return(title+"written by"+author+"published by "+publisher + copyRightDate);
	}
public static class Bookshelf{
	public static void main(String[] args ) {
		  books s1= new books("Harry Potter","JK Rowling","bloomsberry publishers","2019");
		  System.out.println(s1.getTitle()+" "+s1.getAuthor()+" "+s1.getPublisher()+" "+s1.getCopyRightDate());
		  
	  }
}
}

