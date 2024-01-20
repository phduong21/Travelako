let loadMoreBtn = document.querySelector('#load-more-btn');
let currentItem = 3;

loadMoreBtn.onclick = () => {
    let boxes = [...document.querySelectorAll('.travel-listing .travel-detail-card')];
    console.log("alo")
    for (var i = currentItem; i < currentItem + 3; i++) {
        boxes[i].style.display = "block";

        currentItem += 3;

        if (currentItem >= boxes.length) {
            loadMoreBtn.style.display = "none";
        }
    }
}