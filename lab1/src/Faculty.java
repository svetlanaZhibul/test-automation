import java.util.ArrayList;
import java.util.List;

public class Faculty implements MeanCounting{
    private String name;
    private List<Group> groupList;

    public Faculty(){}

    public Faculty(String name) {
        this.name = name;
        groupList = new ArrayList<>();
    }

    public void setGroupList(List<Group> groupList) {
        this.groupList = groupList;
    }

    public List<Group> getGroupList() {
        return groupList;
    }

    public String getName() {
        return name;
    }

    @Override
    public boolean equals(Object other) {
        if (other == null) return false;
        if (!(other instanceof Faculty))return false;
        Faculty otherMyClass = (Faculty) other;
        if (!(this.name.equals(otherMyClass.name))) return false;
        return true;
    }

    public double findMean(){
        double sum = 0;
        for (Group g : groupList){
            sum += g.findMean();
        }
        return (groupList.size()>0) ? sum/groupList.size() : -1;
    }
}
