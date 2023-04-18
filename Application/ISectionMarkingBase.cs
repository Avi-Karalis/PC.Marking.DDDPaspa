using Domain;

namespace Application {
    // Define an interface for the section marking service
    public interface ISectionMarkingBase {
        // Declare a method that accepts a section and returns a Task<Section> after marking the section
        Task<Section> SectionMarkingService(Section section);
    }
}