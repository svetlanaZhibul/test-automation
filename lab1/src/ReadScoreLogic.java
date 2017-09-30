import java.io.FileNotFoundException;
import java.io.FileReader;
import java.util.ArrayList;
import java.util.Scanner;

/**
 * This class helps initializing main structures of program (Students, Groups, etc.) by reading from file.
 */

class ReadScoreLogic {

    public static void scanFile(ArrayList<ScoreSheet> ssh, ArrayList<Student> stds, ArrayList<Subject> subs, University uni, ArrayList<Faculty> facs, ArrayList<Group> groups) {

        String filename = "list.txt";

        int id = 0;
        String group = "";
        String fio = "";
        String faculty = "";
        String subject = "";
        ArrayList<Integer> marks = new ArrayList<>();

        try {
            FileReader fr = new FileReader(filename);

            Scanner scan = new Scanner(fr);
            Scanner linescan;
            Scanner markscan;

            String current;
            while (scan.hasNextLine()) {

                linescan = new Scanner(scan.nextLine());
                linescan.useDelimiter(";"); //;\s*

                while(linescan.hasNext()){
                    current = linescan.next();
                    if(current.matches("([0-9]+\\:)*"))
                    {
                        marks.clear();
                        markscan = new Scanner(current);
                        markscan.useDelimiter(":");
                        while (markscan.hasNextInt()){
                            marks.add(markscan.nextInt());
                        }
//                        for(int i : marks){
//                            System.out.println(i);
//                        }
                    }
                    else if(current.matches("([0-9])+(\\_)([0-9])+")) {
                        group = current;
                        //System.out.println("group: "+group);
                    }
                    else if(current.matches("([А-Я,Ё])(\\.)([А-Я,Ё])(\\.)([А-Я,Ё])")) {
                        fio = current;
                        //System.out.println("fio: "+fio);
                    }
                    else if(current.matches("([a-zA-Z\\s])+"))  //([\w])+
                    {
                        faculty = current;
                        //System.out.println("fac: "+faculty);
                    }
                    else if(current.matches("([^\\d])+")) {
                        subject = current;
                        //System.out.println("sub: "+subject);
                    }
                    else {
                        id = Integer.parseInt(current);
                        //System.out.println("id: "+id);
                    }
                }

                ssh.add(new ScoreSheet(new Student(id,fio,group,faculty),
                                        new Subject(subject), marks));

                if(!stds.contains(new Student(id,fio,group,faculty))) {
                    stds.add(new Student(id, fio, group, faculty));
                }

                if(!subs.contains(new Subject(subject)))
                    subs.add(new Subject(subject));
            }
        } catch (FileNotFoundException e) {
            System.err.println(e);
        }

        for(Student std:stds){
            for(ScoreSheet sc:ssh) {
                if(std.equals(sc.getStudent()))
                    std.setScore(sc.getSubject(), sc);
            }
        }

        for(Subject sub:subs){
            for(ScoreSheet sc:ssh) {
                if(sub.equals(sc.getSubject()))
                    sub.setScore(sc.getStudent(), sc);
            }
        }

        for (Student st : stds) {
            if (!facs.contains(new Faculty(st.getFaculty())))
                facs.add(new Faculty(st.getFaculty()));
        }

        for (Faculty f : facs) {

            for (Student st : stds) {
                if (st.getFaculty().equals(f.getName()))
                {
                    if (!groups.contains(new Group(st.getGroup(), st.getFaculty())))
                        groups.add(new Group(st.getGroup(), st.getFaculty()));

                    groups.get(groups.indexOf(new Group(st.getGroup(), st.getFaculty()))).addStudentToList(st);
                }
            }

            for (Group g : groups) {
                if (g.getFaculty().equals(f.getName()))
                    f.getGroupList().add(g);
            }

            uni.getFacultyList().add(f);
        }

    }
}