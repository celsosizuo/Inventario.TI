echo "[NSWAG] Iniciado"
echo "[NSWAG] Criando server-proxy da api"
"../node_modules/nswag/bin/binaries/Net70/dotnet-nswag.exe" run api.config.nswag && 
ex -s -c "1i|import { AuthenticationService } from '../api/auth/authentication.service';" -c x ../src/shared/api/api-inventario-ti-proxy.ts &&
sed -i -e 's/new HttpHeaders/AuthenticationService.getJwtFullHeaders/g' ../src/shared/api/api-inventario-ti-proxy.ts  &&

read -rsp $'[NSWAG] Finalizado - Pressione uma tecla para fechar !'