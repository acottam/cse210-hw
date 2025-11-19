# YouTube Videos Program - Class Design

## Class Responsibilities and Design

### 1. Video Class
**Responsibility**: Manages individual video information and its associated comments

**Attributes (Member Variables)**:
- `_title` (string): Video title
- `_author` (string): Video creator/author
- `_length` (int): Video duration in seconds
- `_comments` (List<Comment>): Collection of comments for this video

**Methods (Behaviors)**:
- `Video(title, author, length)`: Constructor to initialize video
- `AddComment(comment)`: Adds a comment to the video
- `GetNumberOfComments()`: Returns count of comments
- `DisplayVideoInfo()`: Displays complete video information including comments

### 2. Comment Class
**Responsibility**: Manages individual comment data and display formatting

**Attributes (Member Variables)**:
- `_name` (string): Commenter's name
- `_text` (string): Comment content

**Methods (Behaviors)**:
- `Comment(name, text)`: Constructor to initialize comment
- `GetDisplayText()`: Returns formatted comment string

### 3. VideoLibrary Class
**Responsibility**: Manages collection of videos and provides library-level operations

**Attributes (Member Variables)**:
- `_videos` (List<Video>): Collection of all videos in the library

**Methods (Behaviors)**:
- `VideoLibrary()`: Constructor to initialize empty video collection
- `AddVideo(video)`: Adds a video to the library
- `DisplayAllVideos()`: Displays all videos in the library

## Class Relationships

```
VideoLibrary
├── Contains multiple Video objects
│
Video
├── Contains multiple Comment objects
│
Comment
├── Standalone data object
```

## Program Flow

1. **Initialization**: Create VideoLibrary instance
2. **Video Creation**: Create Video objects with title, author, length
3. **Comment Addition**: Add Comment objects to each Video
4. **Library Population**: Add Video objects to VideoLibrary
5. **Display**: Call DisplayAllVideos() to show all content

## Class Diagram

```
┌─────────────────────┐
│    VideoLibrary     │
├─────────────────────┤
│ - _videos: List<Video>│
├─────────────────────┤
│ + VideoLibrary()    │
│ + AddVideo(video)   │
│ + DisplayAllVideos()│
└─────────────────────┘
           │
           │ contains
           ▼
┌─────────────────────┐
│       Video         │
├─────────────────────┤
│ - _title: string    │
│ - _author: string   │
│ - _length: int      │
│ - _comments: List<Comment>│
├─────────────────────┤
│ + Video(title, author, length)│
│ + AddComment(comment)│
│ + GetNumberOfComments()│
│ + DisplayVideoInfo()│
└─────────────────────┘
           │
           │ contains
           ▼
┌─────────────────────┐
│      Comment        │
├─────────────────────┤
│ - _name: string     │
│ - _text: string     │
├─────────────────────┤
│ + Comment(name, text)│
│ + GetDisplayText()  │
└─────────────────────┘
```

## Method Interaction Flow

```
Main() 
  ↓
VideoLibrary.VideoLibrary() 
  ↓
Video.Video() → Comment.Comment() → Video.AddComment()
  ↓
VideoLibrary.AddVideo()
  ↓
VideoLibrary.DisplayAllVideos() → Video.DisplayVideoInfo() → Comment.GetDisplayText()
```
