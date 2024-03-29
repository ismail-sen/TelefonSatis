


function AddBasket(productId, userId) {

    $.ajax({
        type: 'post',
        url: '/Product/AddBasket',
        data: { 'productId': productId, 'userId': userId },

        success: function (data) {

            var sayi = document.getElementById("cartCount").value;
            sayi = parseInt( sayi )+ 1;
            document.getElementById("cartCount").value = sayi;
            console.log(data);
            console.log("Id:" + data.productsId);

           /* <script>
                var ul = document.creatElement ('ul');
                for (i=0;i<10;i++)
                {
                    var li = document.createElement('li');
                    //li.innerHTML='/Product/AddBasket';
                    ul.appendChild(li);
                }
                document.getElementById('cartlist').appendChild(ul);
            </script>*/
            

        },

        error: function () {

        }



    });


}