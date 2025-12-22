class Book {
    private string $title;
    private string $author;
    private int $currentPage = 0;

    public function __construct(string $title, string $author) {
        $this->title  = $title;
        $this->author = $author;
    }

    public function getTitle(): string {
        return $this->title;
    }

    public function getAuthor(): string {
        return $this->author;
    }

    public function turnPage(): void {
        $this->currentPage++;
    }

    public function getCurrentPage(): int {
        return $this->currentPage;
    }
}


class BookReader {
    public function getPageContent(Book $book): string {
        return "Content of page " . $book->getCurrentPage();
    }
}

class BookLocation {
    public function getLocation(Book $book): string {
        return "Shelf 3, Room 2";
    }
}

class BookRepository {
    public function save(Book $book): void {
        $filename = '/documents/' . $book->getTitle() . ' - ' . $book->getAuthor();
        file_put_contents($filename, serialize($book));
    }
}

interface Printer {
    public function printPage(string $page): void;
}

class PlainTextPrinter implements Printer {
    public function printPage(string $page): void {
        echo $page;
    }
}

class HtmlPrinter implements Printer {
    public function printPage(string $page): void {
        echo '<div style="single-page">' . $page . '</div>';
    }
}


