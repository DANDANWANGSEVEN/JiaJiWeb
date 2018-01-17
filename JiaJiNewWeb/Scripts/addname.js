
function slidePicture(id){

	var oDiv=document.getElementById(id);
	var oBanBox=oDiv.getElementsByTagName('ul')[0];
	var aIm=oBanBox.children;
	var oPoint=oDiv.children[3];
	
	var oBtnPrev=oDiv.children[0];
	var oBtnNext=oDiv.children[1];
		
	for(var i=0; i<aIm.length; i++)
	{
		var aSp=document.createElement('span');

		oPoint.appendChild(aSp);

	};
	

	var aBtn=oPoint.children;
	aBtn[0].className='se';
	var now=0;
	
	oBanBox.innerHTML+=oBanBox.innerHTML;
	oBanBox.style.width=(aIm[0].offsetWidth)*aIm.length+'px';
	var w=oBanBox.offsetWidth/2;
	for(var i=0;i<aBtn.length;i++)
	{
		(function (index){
			aBtn[i].onmouseover=function ()
			{
				//now=index;
				//now-now%5+index
				now=now-now%5+index;
				tab();
			};
		})(i);
	}
	

	
	
	function tab()
	{
		var n=aBtn.length;
		
		for(var i=0;i<aBtn.length;i++)
		{
			aBtn[i].className='';
		}
		if(now>0)
		{
			aBtn[now%n].className='se';
		}
		else
		{
			aBtn[(now%n+n)%n].className='se';
		}
		//startMove(oBanBox, {left: -aIm[0].offsetWidth*now}, {type: 'ease-out'});
		startMove(oBanBox, -(aIm[0].offsetWidth)*now, 700);
		
	}
	oBtnPrev.onclick=function ()
	{
		now--;
		
		tab();
	};
	oBtnNext.onclick=function ()
	{
		now++;
		
		tab();
	};
	var start=setInterval(function(){
		now++;
		tab();
		startMove(oBanBox, -(aIm[0].offsetWidth)*now, 700);
	},3000);
	oDiv.onmouseover=function(){
		clearInterval(start);
	};
	oDiv.onmouseout=function(){
		start=setInterval(function(){
			now++;
			tab();
			startMove(oBanBox, -(aIm[0].offsetWidth)*now, 700);
		},3000);
	};
	//---------------
	
	var left=0;
	
	function startMove(obj, value, time)
	{
		var start=left;
		var dis=value-start;
		
		var count=Math.round(time/30);
		var n=0;
		
		clearInterval(obj.timer);
		obj.timer=setInterval(function (){
			n++;
			
			var a=1-n/count;
			var cur=start+dis*(1-a*a*a);
			
			left=cur;
			
			
			if(left<0)
			{
				obj.style.left=left%w+'px';
			}
			else
			{
				obj.style.left=(left%w-w)%w+'px';
			}
			
			if(n==count)
			{
				clearInterval(obj.timer);
			}
		}, 30);
	}
};



slidePicture('honor');//我们的荣誉
