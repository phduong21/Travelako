let loadMoreBtn = document.querySelector('#load-more-btn');
let boxesList = [...document.querySelectorAll('.travel-listing .travel-detail-card')];
let listSize = boxesList.length;
let currentItem = 3;
if (boxesList.length <= currentItem) {
    loadMoreBtn.style.display = "none";
}

loadMoreBtn.onclick = () => {
    for (var i = currentItem; i < currentItem + 3; i++) {
        boxesList[i].style.display = "block";

        if (currentItem >= listSize) {
            loadMoreBtn.style.display = "none";
        }
    }
    currentItem += 3;
}

let loadMoreBtnSuggest = document.querySelector('#load-more-btn-suggest');
let boxesSuggest = [...document.querySelectorAll('.travel-list-suggest .travel-detail-card')];
let listSuggestSize = boxesSuggest.length;
let currentItemSuggest = 3;
if (boxesSuggest.length <= currentItemSuggest) {
    loadMoreBtnSuggest.style.display = "none";
}

loadMoreBtnSuggest.onclick = () => {
    for (var j = currentItemSuggest; j < currentItemSuggest + 3; j++) {
        boxesSuggest[j].style.display = "block";

        if (currentItemSuggest >= listSuggestSize) {
            loadMoreBtnSuggest.style.display = "none";
        }
    }
    currentItemSuggest += 3;
}