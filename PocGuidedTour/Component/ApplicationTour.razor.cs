using Microsoft.AspNetCore.Components;
using PocGuidedTour.Options;

namespace PocGuidedTour.component;

public class ApplicationTour : ComponentBase
{
    [Inject]
    private GTour.Abstractions.IGTourService GTourService { get; set; }
    [Inject]
    private NavigationManager _navigationManager { get; set; }
    protected AppSettingsOptions TourData { get; set; }
    protected ApplicationTourViewModel ViewModel { get; set; }
    protected override Task OnInitializedAsync()
    {
        ViewModel = new ApplicationTourViewModel()
        {
            TourId = Guid.NewGuid().ToString()
        };
        TourData = AppSettingsOptions.Instance;
        return base.OnInitializedAsync();
    }
  
    public async Task StartTour()
    {
        var firstStepUrl = TourData.Steps[0].Url;
        if (!_navigationManager.Uri.EndsWith(firstStepUrl) )
        {
            _navigationManager.NavigateTo(firstStepUrl);
        }
        await GTourService.StartTour(ViewModel.TourId);
    }
    public async Task NavigateNextPage(AppSettingsOptions.TourItem currentStep)
    {
        var nextStep = TourData.Steps.Find(x => x.TourStepSequence == currentStep.TourStepSequence + 1);
        var nextUrl = nextStep?.Url;
        if ( nextUrl != currentStep.Url && nextUrl is not null)
        {
            _navigationManager.NavigateTo(nextUrl);
        }
    }
    public async Task NavigatePreviousPage(AppSettingsOptions.TourItem currentStep)
    {
        var previousStep = TourData.Steps.Find(x => x.TourStepSequence == currentStep.TourStepSequence - 1);
        var previousUrl = previousStep?.Url;
        if (previousUrl != currentStep.Url && previousUrl is not null)
        {
            _navigationManager.NavigateTo(previousUrl);
        }
    }
}