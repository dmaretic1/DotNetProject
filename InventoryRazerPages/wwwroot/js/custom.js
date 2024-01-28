var image = document.getElementById("imageHolder")

function Main() {
    Rotation()
    setInterval(function() {Rotation()}, 2000)
  }

function Rotation() {
    image.style.transform = "rotate(10deg)"
    setTimeout(() => {
        image.style.transform = "rotate(-10deg)"
    }, 1000)
}
  
Main()