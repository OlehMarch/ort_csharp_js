function Velement()
{
    this.type = "";
	this.id = "";
	this.value = "";
	this.x = "";
	this.y = "";
	this.width = "";
	this.height = "";
	
	this.isFull = false;
	
	this.Clear = function()
	{
		this.type = "";
		this.id = "";
		this.value = "";
		this.x = "";
		this.y = "";
		this.width = "";
		this.height = "";
		
		this.isFull = false;
	}
	
	this.IsFullCheck = function()
	{
		if (this.type != "" && this.id != "" && this.x != "" 
		 && this.y != "" && this.width != "" && this.height != "")
		{
			this.isFull = true;
		}
		else
		{
			this.isFull = false;
		}
		
		return this.isFull;
	}
	
}