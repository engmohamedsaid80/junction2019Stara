
public class Worker {
    public Team Team { get; set; }

    [Key]
    public int WorkerId { get; set; }
    public String Name { get; set; }
    public String PhoneNumber { get; set; }
    public String Email { get; set; }
    public String Status { get; set; }
    public String Longitude { get; set; }
    public String Latitude { get; set; }

    public List<Task> Tasks { get; set; }
    public List<Skill> Skills { get; set; }
    public List<Hours> Hours { get; set; }
}

public class Foreman {
    public Team Team { get; set; }

    [Key]
    public int ForemanId { get; set; }
    public String Name { get; set; }
    public String PhoneNumber { get; set; }
    public String Email { get; set; }
    public String Status { get; set; }

    public List<Project> Projects { get; set; }
}

public class Team {
    [Key]
    public int TeamId { get; set; }
    public String Name  { get; set; }
    public String Foreman { get; set; }
    
    public List<Worker> Workers { get; set; }
}

public class Task {
    public Project Project { get; set; }
    
    [Key]
    public int TaskId { get; set; }
    public Worker Worker { get; set; }
    public String Streetname { get; set; }
    public String BuildingName { get; set; }
    public String Longitude { get; set; }
    public String Latitude { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndTime { get; set; }
    public int Duration { get; set; } 

    public List<TaskUpdate> TaskUpdates { get; set; }
}

public class Project {
    public Foreman Foreman { get; set; }

    [Key]
    public int ProjectId { get; set; }
    public String Longitude { get; set; }
    public String Latitude { get; set; }
    public String Streetname { get; set; }
    public String BuildingName { get; set; }
    public String Urgency { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndTime { get; set; }
    public int Duration { get; set; }

    public List<Task> Tasks { get; set; }
    public List<Feedback> Feedbacks { get; set; }
}

public class TaskUpdate {
    public Task Task { get; set; }

    public String Status { get; set; }
    public String Description { get; set; }
    public String PictureUrl { get; set; }
    public DateTime TimeStamp { get; set; }    
}

public class Feedback {
    public Project Project { get; set; }

    public int Description { get; set; }
}

public class Skill {
    public Worker Worker { get; set; }

    public String Description { get; set; }
}

public class Hours {
    public Worker Worker { get; set; }

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int Duration { get; set; }
}