namespace Software2KnowledgeCheck1
{
  internal class Construction
  {
    public List<Building> Buildings { get; } = new List<Building>();

    public void CreateBuilding(Apartment apartment, HighRise highrise)
    {
      // Get materials
      var materialRepo = new MaterialsRepo();
      var materialsNeeded = materialRepo.GetMaterials();

      var permitRepo = new ZoningAndPermitRepo();

      var apartmentWasMade = ConstructBuilding<Apartment>(materialsNeeded, permitRepo.GetPermit(), permitRepo.ZoningApproves());
      var highRiseWasMade = ConstructBuilding<HighRise>(materialsNeeded, permitRepo.GetPermit(), permitRepo.ZoningApproves());

      if (apartmentWasMade)
      {
        Buildings.Add(apartment);
      }
      else if (highRiseWasMade)
      {
        Buildings.Add(highrise);
      }
    }

    public bool ConstructBuilding<T>(List<string> materials, bool permit, bool zoning) where T : Building
    {
      if (permit && zoning)
      {
        foreach (var material in materials)
        {
          if (material == "concrete")
          {
            // start laying foundation
          }
          else if (material == "Steel")
          {
            // Start building structure
          }
          // etc etc...

        }
        return true;
      }
      else
      {
        return false;
      }
    }


  }
}